using CompileTeijkhrebKursach.Model;
using CompileTeijkhrebKursach.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CompileTeijkhrebKursach.Presenter
{
    //Сам класс сканера :D
    public class Lexer
    {
        //Переменные, необходимые для работы сканера
        private string text;
        private int position;
        private List<Lexem> lexemsList;
        private ResourceManager _res;

        //Конструктор
        public Lexer(string textToScan, ResourceManager res)
        {
            _res = res ?? throw new ArgumentNullException("Не найден файл локализации для выбранного языка!");
            text = textToScan;
            position = 0;
            lexemsList = new List<Lexem>();
        }

        //Метод сканирования
        public List<Lexem> Scan()
        {
            while (position < text.Length)
            {
                char currentChar = text[position];

                if (char.IsLetter(currentChar))
                {
                    ProcessIdentifier();
                }
                else if (char.IsDigit(currentChar))
                {
                    ProcessNumber();
                }
                else
                {
                    if (ProcessSymbol()) break;
                }
            }
            return lexemsList;
        }

        //Обработка идентификатора
        private void ProcessIdentifier()
        {
            int start = position;
            while (position < text.Length && char.IsLetterOrDigit(text[position]))
            {
                position++;
            }
            string lexeme = text.Substring(start, position - start);
            int code = lexeme == "format" ? 2 : 1;
            lexemsList.Add(new Lexem(code, lexeme, start, position, _res));
        }

        //Обработка числа
        private void ProcessNumber()
        {
            int start = position;
            bool isDouble = false;
            bool isScientific = false;

            while (position < text.Length && (char.IsDigit(text[position]) || text[position] == '.'))
            {
                if (text[position] == '.')
                {
                    isDouble = true;
                }
                position++;
            }

            if (position < text.Length && (text[position] == 'e' || text[position] == 'E'))
            {
                isScientific = true;
                position++;
                if (position < text.Length && (text[position] == '+' || text[position] == '-'))
                {
                    position++;
                }
                while (position < text.Length && char.IsDigit(text[position]))
                {
                    position++;
                }
            }

            string lexeme = text.Substring(start, position - start);
            int code;
            if (isScientific)
            {
                if (lexeme.Contains("-") | lexeme.Contains("+"))
                {
                    if (isDouble)
                    {
                        code = lexeme.Contains("-") ? 14 : 15;
                    }
                    else
                    {
                        code = lexeme.Contains("-") ? 10 : 11;
                    }
                }
                else
                {
                    lexemsList.Add(new Lexem(19, lexeme, start, position, _res));
                    return;
                }
            }
            else
            {
                code = isDouble ? 13 : 12;
            }
            lexemsList.Add(new Lexem(code, lexeme, start, position, _res));
        }

        //Обработка символа
        private bool ProcessSymbol()
        {
            int start = position;
            char currentChar = text[position++];
            int code;
            switch (currentChar)
            {
                case '=': code = 4; break;
                case '"': ProcessString(); return false;
                case '-': code = 7; break;
                case '+': code = 8; break;
                case '.': code = 9; break;
                case '(': code = 16; break;
                case ')': code = 17; break;
                case ';': code = 18; 
                    if (position >= text.Length)
                    {
                        lexemsList.Add(new Lexem(code, currentChar.ToString(), start, position, _res));
                        return true;
                    }
                    else
                    {
                        break;
                    }
                default: code = 19; break;
            }
            lexemsList.Add(new Lexem(code, currentChar.ToString(), start, position, _res));
            return false;
        }

        //Обработка строки
        private void ProcessString()
        {
            int start = position - 1;
            StringBuilder sb = new StringBuilder();
            bool isFString = false;

            while (position < text.Length)
            {
                if (text[position] == '"')
                {
                    position++;
                    break;
                }
                sb.Append(text[position]);
                if (text[position] == '{' && position + 3 < text.Length && text.Substring(position, 4) == "{:f}")
                {
                    isFString = true;
                    position += 4;
                }
                else
                {
                    position++;
                }
            }

            string lexeme = text.Substring(start, position - start);
            int code = isFString ? 6 : 5;
            lexemsList.Add(new Lexem(code, lexeme, start, position, _res));
        }
    }
}
