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
