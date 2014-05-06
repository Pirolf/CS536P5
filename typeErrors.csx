//Bad tests go here
//Include an instance of error for each relevant
//operator, in each part of prog where the err 
//can occurr

//WRITE_FN, READ_FN

int f1(){
	return 1;
}
int f4(){
   return 0;
}
void writef1(){
	cout << f1;
   cout << 1 + f1;
	cin >> f1;
   cin >> f1 / f4;
}
void writef2_nested(){
   cout << writef1;
   cin >> writef1;
}
//WRITE_STRUCT, READ_STRUCT_NAME
struct space{
	int dim;
};
struct spaceOutsideSpace{
   struct space s;
   int speed;
};
void writeStruct(){
	cout << space;
   cout << space + space/2;
	cin >> space;
   cin >> space || 1;
}
void writeStruct_nested(){
   struct spaceOutsideSpace sos;
   cout << spaceOutsideSpace;
   cin >> spaceOutsideSpace;
   //write, read a struct variable's struct field
   cout << sos.s;
   cin >> sos.s;
}
//WRITE_STRUCT_VAR, READ_STRUCT_VAR
struct space outerspace;
struct spaceOutsideSpace recursiveSpace;
void writeStructVar(){
	cout << outerspace;
	cin >> outerspace;

   cout << recursiveSpace;
   cin >> recursiveSpace;

   cout << recursiveSpace.s;
   cin >> recursiveSpace.s;
}

//CALL_NON_FN
int i1;
int i2;
bool b1;
int callNonFn(){
   int i3;
   bool b3;
   struct space spaceHere;
   struct spaceOutsideSpace sosHere;

	i1();
	b1();
	space(); //struct
	spaceOutsideSpace(); //nested struct
   i3(); //int defined in curr scope
   b3(); //bool defined in curr scope
   spaceHere(); //struct var defined in curr scope
   sosHere(); //nested struct var defined in curr scope

   outerspace(); //struct var
   recursiveSpace(); //nested struct var
   if(outerspace() && b3()){
      recursiveSpace();
   }else{
      sosHere();
      return spaceHere();
   }
   while(space() || b1()){
      i3();
      return recursiveSpace() + i3();
   }
   return space();
}
//CALL_FN_WITH_WRONG_NUM_ARGS
int wrongArgsCallee(int i1, int i2, bool b1){
}
int i10;
bool b10;
int wrongArgsCaller(int i1, bool b1){
   int i11;   
   bool b11;
   wrongArgsCallee(1, 2); //actual < param
   wrongArgsCallee(i10, b10);
   wrongArgsCallee(i10+i11, b10 && b11);

   wrongArgsCallee(1, 2, true, 3); // actual > param
   wrongArgsCallee(i10 * 2 /i11, i10 > 1 || i11 == i10, i11-2, !b10);
   wrongArgsCallee(); // no actuals
   i11 = wrongArgsCallee(i10, b10) + b11 = b11;
   b11 = wrongArgsCallee(i10 * 2 /i11, i10 > 1 || i11 == i10, i11-2, !b10);
}
//test if there are cascading errors 
int wrongArgsCallerCaller(){
   int x;
   wrongArgsCaller(1);
   wrongArgsCaller(1, true, 2);
   wrongArgsCaller();
   return wrongArgsCaller(x*2);
}
//ACTUAL_NOT_MATCH_FORMAL_TYPE
bool actualFormalMismatchCallee(int i1, bool i2){
   return false;
}
void actualFormalMismatchCaller(){
   int i20;
   bool b20;
	actualFormalMismatchCallee(false, true);
   if(actualFormalMismatchCallee(1, 2)){
      actualFormalMismatchCallee(false, 3);
   }
   if(!actualFormalMismatchCallee(b10, true)){
      actualFormalMismatchCallee(b10 || b20 , true);
   }else{
      actualFormalMismatchCallee(i20, -i10);
   }
   while(actualFormalMismatchCallee(b10 && i20 <= 1, i20*i20) && false){
      actualFormalMismatchCallee(b10, b20);
   }
   actualFormalMismatchCallee(!b10 || !b20, b10 || b20);
   
}
//RET_VAL_MISSING
int retValMissing(){
	return;
}
int retValMissing2(){
   if(true){
      return retValMissing();
      if(1==2){
         return;
      }
   }else{
      return;
   }
   while(false){
      return
   }
}
//RET_VAL_IN_VOID_FN
void shouldNotRetVal1(){
	return 1;
}
void shouldNotRetVa1Exp(){
   int i;
   return i + i10;
}
void shouldNotRetVal2(){
	return true;
}
int retInt(){
   return 3;
}
void shouldNotRetVal2Exp(){
   bool b;
   int x;
   if(!b){
      return b && b10;
   }else{
      return false;
   }
   if(b){
      return b10 || b;
      if(false){
         return 1;
      }
      if(b && true){
         return -x + 1;
      }else{
         return retInt() * x;
      }
   }
   while(b){
      return b;
   }
   
}
void shouldNotRetStructField1(){
   struct space sss;
   return sss.dim;
}
void shouldNotRetStructVar(){
   struct space sss;
   return sss;
}
void shouldNotRetStructName(){
   return space;
}
void shouldNotRetStructField2(){
   return outerspace.dim;
}
void shouldNotRetNestedStructField1(){
   return recursiveSpace.s.dim;
}
bool retBool(){
   return true;
}
//WRONG_RET_TYPE_FOR_NON_VOID
int shouldRetInt1(){
   int x;
   bool b;
   if(x == 3){
      return b;
   }else{
      return x!=2;
      while(1){
         return retBool();
      }
      return x > 1;
   }
   if(1==2){
      return space;
   }
   if(x > 2){
      return recursiveSpace;
   }else{
      return recursiveSpace.s;
   }
	return true;
}
int shouldRetInt2(){
   bool b;
   return b ||!b10;
}
int shouldRetInt3(){
   return space;
}
int shouldRetInt4(){
   return recursiveSpace;
}
bool shouldRetBool1(){
	return 1;
}
bool shouldRetBool2(){
   int i;
   return i10 *i + 1;
}
bool shouldRetBool3(){
   return f1();
}
int f3(){
   int x;
   return x;
}
bool shouldRetBool4(){
   return f1() * f3() + 3;
}
bool f2(){
   return false;
}
int shouldRetInt5(){
   return f2() && f2();
}


// LOG_OP_TO_NON_BOOL
int x1;
void lnb(int x, int y) {
   x = !x;
   x = y || x;
   x = y && x;
   x = x1 && x;
   if(!x){
      y = x && 2 || y;
   }else{
      x = x && y;
   }
   while(y || 3){
      x = 3 + !y;
      if(space && outerspace){//struct name
         x = !recursiveSpace;//struct var
         x = recursiveSpace.speed && recursiveSpace.s;
      }
   }
}

// ARITH_OP_TO_NON_NUM
bool b31;
void aonn(bool x, bool y) {
   x = x+y;
   x = x-y;
   x = x*y;
   x = x/y;
   x = -x;
   if(x + 3 > 2){
      x = !(x - x/2) && y;
      x++;
      x--;
   }else{
      x = y * 2;
      x++;
      x--;
      x = -space *recursiveSpace/recursiveSpace.s-space;
   }
   while(x + y){
      y = (x + y) || x;
      space++; //struct name
      recursiveSpace--;//struct var
   }
   x++;
   x--;
   x= b31*2;
   x = x + y - y * 2;
   x = 2 || i10 - x * y;
}

// REL_OP_TO_NON_NUM
void ronn(bool x, bool y, bool z) {
   x = x > y;
   x = x < y;
   x = x >= y;
   x = x <= y;
   if(x > y + z){
      x = x < z - y;
   }else{
      x = (x >= z + 3);
      x = !(x >= z);
      x = !(3 >= z);
   }
   while( x < z){
      z = z <= x;
      z = space <= recursiveSpace.s;
      while(recursiveSpace.speed > space){
         if(recursiveSpace.s < outerspace.dim){

         }
      }
   }
}

// EQ_OP_TO_VOID_FN, EQ_OP_TO_FN, and TYPE_MISMATCH
void eq(int x, bool y) {
   x = ronn(y, y) != aonn(y, y);
   x = ronn(y, y) == aonn(y, y);
   x = aonn != ronn;
   x = x != y;
   x = aonn == ronn;
   x = x == y;
   if(ronn(y, y) == aonn(y, y)){
      if(space == recursiveSpace && space == x){
      //struct name == struct var, struct name==int 
         x = x != recursiveSpace;
         y = y == space; //bool == struct var
      }
      x = x != y;
   }else{
      x = ronn(y, y) == aonn(y, y);
   }
   while(x==y && y!= recursiveSpace){
      x = aonn == ronn;
   }
}

// NON_BOOL_EXP_IN_IF_COND and NON_BOOL_EXP_IN_WHILE_COND
void nbexp(int x) {
   int y;
   while (x) {
      x++;
   }
   while(x+y){
      y--;
   }
   while(1){
      x++;
      while(space){//struct name
         if (x) {
            x--;
            x = !x;
         }
      }
   }
   if(space + outerspace + 1){
      while(recursiveSpace * 3){
      }
   }
   if(x*y){
      x = x + y;
   }
   if(space){
      if(outerspace){//struct name
      }
   }else{
      while(outerspace.dim){
         y--;
      }
      
   }
   if (recursiveSpace) {//struct var
     x++;
   } else {
     x--;
   }
}

struct ocean{
   int sea;
};
int water;
//FN_ASSIGN, STRUCT_NAME_ASSIGN, STRUCT_VAR_ASSIGN
void forCascading(int k){
   nbexp = eq;
   ocean = space;
   outerspace = recursiveSpace;
   if(k>1){
      nbexp = eq;
   }else{
      ocean = space;
      while(k==0){
         outerspace = recursiveSpace;
      }
   }
}
bool forAllErrs(int c1){
   if(c1 == 3){
      return c1;
   }
   return 2;    
}
//Test Cascading Errors
void noCascading(){
   struct ocean atlantic;
   cout << atlantic + 1;         // atlantic + 1 is an error; the write is OK
   cin >> (true + 3) * 4;         // true + 3 is an error; the * is OK
   water = true && (false || 3);   // false || 3 is an error; the && is OK
   forCascading("a" * 4);            // "a" * 4 is an error; the call is OK
   water = 1 + atlantic();               // p() is an error; the + is OK
   if((true + 3) == water){

   }        // true + 3 is an error; the == is OK                       // regardless of the type of x
}
void shouldPrintAllErrors(){
   int a;
   int i;
   a = true + "hello";    // one error for each of the non-int operands of the +
   a = 1 + forAllErrs(true); // one for the bad arg type and one for the 2nd operand of the +
   i = 1 + forAllErrs(1, 2);      // one for the wrong number of args and one for the 2nd operand of the +
   return 3 + true;    // in a void function: one error for the 2nd operand to +
                  // and one for returning a value
}
