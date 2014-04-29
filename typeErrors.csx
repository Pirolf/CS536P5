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
int lnb(int x, int y) {
   x = !x;
   x = y || x;
   x = y && x;
}

// ARITH_OP_TO_NON_NUM
int aonn(bool x, bool y) {
   x = x+y;
   x = x-y;
   x = x*y;
   x = x/y;
   x = -x;
}

// NON_BOOL_EXP_IN_IF_COND and NON_BOOL_EXP_IN_WHILE_COND
int nbexp(int x) {
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
