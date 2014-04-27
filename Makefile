###
# This Makefile can be used to make a parser for the CSX language
# (parser.class) and to make a program (P5.class) that tests the parser, nameAnalysis,
# typeCheck and unparse methods in ast.java.
#
# make clean removes all generated files.
#
###

JC = javac
P5.class: P5.java parser.class Yylex.class ASTnode.class
	$(JC) -g P5.java

parser.class: parser.java ASTnode.class Yylex.class ErrMsg.class
	$(JC) parser.java

parser.java: CSX.cup
	java java_cup.Main < CSX.cup

Yylex.class: CSX.jlex.java Sym.class ErrMsg.class
	$(JC) CSX.jlex.java

ASTnode.class: ast.java
	$(JC) -g ast.java

CSX.jlex.java: CSX.jlex Sym.class
	java JLex.Main CSX.jlex

Type.class: Type.java
	$(JC) -g Type.java

Sym.class: Sym.java Type.class
	$(JC) -g Sym.java

Sym.java: CSX.cup
	java java_cup.Main < CSX.cup

ErrMsg.class: ErrMsg.java
	$(JC) ErrMsg.java

ErrorMessages.class: ErrorMessages.java
	$(JC) ErrorMessages.java
###
# clean
###
clean:
	rm -f *~ *.class parser.java CSX.jlex.java
