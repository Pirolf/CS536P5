//Bad tests go here
//Include an instance of error for each relevant
//operator, in each part of prog where the err 
//can occurr

//WRITE_FN, READ_FN

int f1(){
	return 1;
}
void writef1(){
	cout << f1;
	cin >> f1;
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
	cin >> space;
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
void callNonFn(){
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
}
//CALL_FN_WITH_WRONG_NUM_ARGS
void wrongArgsCallee(int i1, int i2, bool b1){
}

int i10;
bool b10;
void wrongArgsCaller(int i1, bool b1){
   int i11;   
   bool b11;
	wrongArgsCallee(1, 2); //actual < param
   wrongArgsCallee(i10, b10);
   wrongArgsCallee(i10+i11, b10 && b11);

	wrongArgsCallee(1, 2, true, 3); // actual > param
   wrongArgsCallee(i10 * 2 /i11, i10 > 1 || i11 == i10, i11-2, !b10);
	wrongArgsCallee(); // no actuals
}
//test if there are cascading errors 
void wrongArgsCallerCaller(){
   wrongArgsCaller(1);
   wrongArgsCaller(1, true, 2);
   wrongArgsCaller();
}
//ACTUAL_NOT_MATCH_FORMAL_TYPE
void actualFormalMismatchCallee(int i1, bool i2){

}
void actualFormalMismatchCaller(){
   int i20;
   bool b20;
	actualFormalMismatchCallee(false, true);
	actualFormalMismatchCallee(1, 2);
	actualFormalMismatchCallee(false, 3);

   actualFormalMismatchCallee(b10, true);
   actualFormalMismatchCallee(b10 || b20 , true);
   actualFormalMismatchCallee(i20, -i10);
   actualFormalMismatchCallee(b10 && i20 <= 1, i20*i20);
   actualFormalMismatchCallee(b10, b20);
   actualFormalMismatchCallee(!b10 || !b20, b10 || b20);
   
}
//RET_VAL_MISSING
int retValMissing(){
	return;
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
void shouldNotRetVal2Exp(){
   bool b;
   return b && b10;
}
void shouldNotRetStructField1(){
   struct space sss;
   return sss.dim;
}
void shouldNotRetStructField2(){
   return outerspace.dim;
}
void shouldNotRetNestedStructField1(){
   return recursiveSpace.s.dim;
}
//WRONG_RET_TYPE_FOR_NON_VOID
int shouldRetInt1(){
	return false;
}
int shouldRetInt2(){
   bool b;
   return b ||!b10;
}
bool shouldRetBool1(){
	return 1;
}
bool shouldRetBool2(){
   int i;
   return i10 *i + 1;
}

// LOG_OP_TO_NON_BOOL
int x1;
void lnb(int x, int y) {
   x = !x;
   x = y || x;
   x = y && x;
   x = x1 && x;
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
      x = x - x/2;
   }else{
      x = y * 2;
   }
   while(x + y){
      y = x + y;
   }
  // x = x++;
  // x = x--;
   x= b31*2;
   x = x + y - y * 2;
   x = 2 + i10 - x * y;
}

// REL_OP_TO_NON_NUM
void ronn(bool x, bool y, bool z) {
   x = x > y;
   x = x < y;
   x = x >= y;
   x = x <= y;
   b31 = (b31 != true);
   b31 = (x == y);
   b31 = (x == (y == z));
}

// EQ_OP_TO_VOID_FN, EQ_OP_TO_FN, and TYPE_MISMATCH
void eq(int x, bool y) {
   x = ronn(y, y) != aonn(y, y);
   x = ronn(y, y) == aonn(y, y);
   x = aonn != ronn;
   x = x != y;
   x = aonn == ronn;
   x = x == y;
}

// NON_BOOL_EXP_IN_IF_COND and NON_BOOL_EXP_IN_WHILE_COND
void nbexp(int x) {
   while (x) {
      x++;
   }
   if (x) {
      x--;
   }
   if (x) {
     x++;
   } else {
     x--;
   }
}

struct ocean{
   int sea;
};
int water;
void forCascading(int k){

}
bool forAllErrs(int c1){
   return false;
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
