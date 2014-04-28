//Bad tests go here
//Include an instance of error for each relevant
//operator, in each part of prog where the err 
//can occurr

//WRITE_FN

int f1(){
	return 1;
}
void writef1(){
	cout << f1;
}

//WRITE_STRUCT
struct space{
	int a;
};
void writeStruct(){
	cout << space;
}

//WRITE_STRUCT_VAR
struct space outerspace;
void writeStructVar(){
	cout << outerspace;
}