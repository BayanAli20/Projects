%{
  #include <stdio.h>
  #include <stdlib.h>
%}

/* declare tokens */
%token  IF ELSE
%token NUMBER Identifier
%token ADD SUB MUL DIV OR AND POWER
%token LE_OP GE_OP EQ_OP NE_OP

%%
programe : stmt {printf("Accepted");}

stmt:
           IF '(' cond ')'  '{' stmt '}' ELSE '{' stmt '}' stmt     
          |IF '(' cond ')'  '{' stmt '}' ELSE '{' stmt '}'
          |IF '(' cond ')' '{' stmt '}'  stmt
          |IF '(' cond ')' '{' stmt '}'    
          |assign
          |expression
          
;
assign:
            Identifier '=' exp ';' stmt
            |Identifier '=' exp ';'
;
expression:
	exp ';'
	|exp ';'  stmt   
;
cond: cterm|
          cond OR cterm
;         
cterm: cfact|
            cterm AND cfact          
;           
cfact:   
           exp compare exp
;
compare:
                '<'
               |'>'|LE_OP|GE_OP|EQ_OP|NE_OP
;
exp: term 
| exp ADD term {$$ = $1 + $3 ;}
| exp SUB term {$$ = $1 - $3 ;}
;
term: factor 
| term MUL factor {$$ = $1 * $3 ;} 
| term DIV factor  {$$ = $1 / $3 ;}
;
factor: fact POWER factor
          |fact
;
fact:  NUMBER
         |'('exp')' {$$ = $2 ;}
;
%%
main(int argc, char **argv)
{
yyparse();
}
yyerror(char *s)
{
   fprintf(stderr, "error: %s\n", s);
}