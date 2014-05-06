// good tests go here
// calls ProgramNode's, DeclListNode's, and VarDeclNode's typeCheck()
int i;
bool t;

struct point {
   int x;
   int y;
};

// calls FnDeclNode's typeCheck()
int func (int x, bool b) {
   // VarDeclNode's typeCheck
   bool a;
   struct point test;
   test.x = 1;
   test.y = 2;
   // IdNode's, AndNode's, OrNode's, TrueNode's, FalseNode's typeCheck
   a = b && true || false;
   // <, >, <=, >=, !=, and ==Node's typeCheck
   a = a && (x<i || i>x || x==i || x!=i || x>=i || x<=i);
   // NotNode's typeCheck
   a = !(!a);
   // IfElseStmtNode's, ExpNode's, & IdNode's typeCheck
   if (a) {
      // ReturnStmtNode's & IdNode's typeCheck
      return x;
   }
   else {
      // AssignStmtNode's, IdNode's typeCheck
      i = 1;
   }
   // IfStmtNode's typeCheck
   if (a) {
      return x;
   }

   // ReturnStmtNode's, UnaryMinusNode's, PlusNode's, DivideNode's, MinusNode's,
   // TimesNode's, & IntLitNode's typeCheck
   return -(4+3/2-5*2);
}

// FnDeclNode's typeCheck
bool test (int x, int y) {
   // WhileStmtNode's checkType
   while (x != y) {
      x = y;
   }
   // ReturnStmtNode's, CallExpNode's typeCheck
   return ((x+y) == func(x, true));
   // CallStmtNode's typeCheck
   func(x, true);
}
