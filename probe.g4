grammar LexerGrammar;

// Основное правило - программа состоит из выражений и EOF
prog: expr+ EOF;

expr
    : NUMBER      # NumberExpr
    | IDENTIFIER  # IdentifierExpr
    | STRING      # StringExpr
    | FSTRING     # FStringExpr
    | SYMBOL      # SymbolExpr
    ;

// Лексемы
NUMBER 
    : DIGIT+ ('.' DIGIT+)? (('e' | 'E') ('+' | '-')? DIGIT+)?
    ;

IDENTIFIER
    : [a-zA-Z_][a-zA-Z0-9_]*
    ;

STRING
    : '"' ~["]* '"'
    ;

FSTRING
    : '"' .*? '{:f}' .*? '"'
    ;

SYMBOL
    : '=' | '+' | '-' | ';' | '(' | ')'
    ;

// Лексемы для чисел и пробелов
fragment DIGIT
    : [0-9]
    ;

WS
    : [ \t\r\n]+ -> skip
    ;