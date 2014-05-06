// good tests go here
// calls ProgramNode's, DeclListNode's, and VarDeclNode's typeCheck()
int i;
bool t;

// StructDeclNode's typeCheck
struct point {
   int x;
   int y;
};

// calls FnDeclNode's, FnBody's, StmtListNode's, StmtNode's,
// FormalDeclNode's & FormalListNode's typeCheck()
int func (int x, bool b) {
   // VarDeclNode's typeCheck
   bool a;
   struct point test;
   // DotAccessNode's typeCheck
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
      return x*x -3/test.x;
   }
   else {
      // AssignStmtNode's, IdNode's typeCheck
      i = 1;
   }
   // IfStmtNode's typeCheck
   if (a) {
      return x;
   }
   while(!a){
      return test.x;
   }
   // ReturnStmtNode's, UnaryMinusNode's, PlusNode's, DivideNode's, MinusNode's,
   // TimesNode's, & IntLitNode's typeCheck
   return -(4+3/2-5*2);
   // PostDec/IncNode's typeCheck
   test.x++;
   test.y++;
   // Read/WriteStmtNode's, and StringLitNode's typeCheck
   cin >> 3;
   cout << "hello";
   cin >> test.x + test.y;
   cout << test.x == 1 && test.y >= 3;
}

// FnDeclNode's typeCheck
bool test (int x, int y) {
   // WhileStmtNode's checkType
   while (x != y) {
      while (x == y) {
         return true;
      }
      x = y;
      return func(1, x-y > -1) > 2;
   }
   // ReturnStmtNode's, CallExpNode's typeCheck
   return ((x+y) == func(x, true));
   // CallStmtNode's typeCheck
   func(x, true);
}
