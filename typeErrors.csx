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

//WRITE_STRUCT, READ_STRUCT_NAME
struct space{
	int dim;
};
void writeStruct(){
	cout << space;
	cin >> space;
}

//WRITE_STRUCT_VAR, READ_STRUCT_VAR
struct space outerspace;
void writeStructVar(){
	cout << outerspace;
	cin >> outerspace;
}

//CALL_NON_FN
int i1;
bool b1;
void callNonFn(){
	i1();
	b1();
	space();
	outerspace();
}
//CALL_FN_WITH_WRONG_NUM_ARGS
void wrongArgsCallee(int i1, int i2, bool b1){

}
void wrongArgsCaller(){
	wrongArgsCallee(1, 2);
	wrongArgsCallee(1, 2, true, 3);
	wrongArgsCallee();
}
//ACTUAL_NOT_MATCH_FORMAL_TYPE
void actualFormalMismatchCallee(int i1, bool i2){

}
void actualFormalMismatchCaller(){
	actualFormalMismatchCallee(false, true);
	actualFormalMismatchCallee(1, 2);
	actualFormalMismatchCallee(false, 3);
}
//RET_VAL_MISSING
int retValMissing(){
	return;
}
//RET_VAL_IN_VOID_FN
void shouldNotRetVal1(){
	return 1;
}
void shouldNotRetVal2(){
	return true;
}
//WRONG_RET_TYPE_FOR_NON_VOID
int shouldRetInt(){
	return false;
}
bool shouldRetBool(){
	return 1;
}
int shouldRetInt_i1(){
	return b1;
}
bool shouldRetBool_b1(){
	return i1;
}

// LOG_OP_TO_NON_BOOL
void lnb(int x, int y) {
   x = !x;
   x = y || x;
   x = y && x;
}

// ARITH_OP_TO_NON_NUM
void aonn(bool x, bool y) {
   x = x+y;
   x = x-y;
   x = x*y;
   x = x/y;
   x = -x;
}

// REL_OP_TO_NON_NUM
void ronn(bool x, bool y) {
   x = x > y;
   x = x < y;
   x = x >= y;
   x = x <= y;
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
