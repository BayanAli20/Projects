%{
#include <stdio.h>
#include <stdlib.h>
#include "y.tab.h"
extern int yylval;
%}
                                                                                                                                                     
%%
"if"    			{ return IF;}
"else"                                           { return ELSE;}
[-+]?([0-9]*\.?[0-9]+|[0-9]+\.[0-9]*)([eE][+-]?[0-9]+)?  { yylval = atoi(yytext);return NUMBER; }								
[A-Za-z_][A-Za-z_0-9]*  	{ return  Identifier;} 									
"+" 			{ return ADD; }
"-" 			{ return SUB; }
"*" 			{ return MUL;}
"/" 			{ return DIV; }
"^"   			{ return POWER;}
"&"                                             { return AND;}
"|"                                                { return OR; }
"="                             	{ return ('=');}
">"           	 		{ return  ('>');}
"<"           	 		{ return ('<');} 
"<=" 			{ return LE_OP; }
">=" 			{ return GE_OP; }
"=="			 { return EQ_OP; }
"!="			 { return NE_OP; }    
"{"                                              { return('{'); }
"}"                                              { return('}'); }
"("          			{ return ('(');}
")"            			{ return (')');}
";"                             		{ return (';');}
[ \t]* 			{ }
\n 			{ }
"//".*  			{ }
"/*"([^*]|\*+[^/])*"*/" 	{/*ignore Multi Line Comment */ }
.                                                    {printf("*****mystery*****");}
%%
int yywrap()
{
  return 1;
}