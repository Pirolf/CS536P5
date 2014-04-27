public class ErrorMessages{
	public static final String WRITE_FN = "Attempt to write a function";
	public static final String WRITE_STRUCT = "Attempt to write a struct";
	public static final String WRITE_STRUCT_VAR = "Attempt to write a struct variable";
	public static final String READ_FN = "Attempt to read a function";
	public static final String READ_STRUCT_NAME = "Attempt to read a struct name";
	public static final String READ_STRUCT_VAR = "Attempt to read a struct variable";
	public static final String CALL_NON_FN = "Attempt to call a non-function";
	public static final String CALL_FN_WRONG_NUM_ARGS = "Function call with wrong number of args";
	public static final String ACTUAL_NOT_MATCH_FORMAL_TYPE = "Type of actual does not match type of formal";
	public static final String RET_VAL_MISSING = "Missing return value";
	public static final String RET_VAL_IN_VOID_FN = "Return with a value in a void function";
	public static final String WRONG_RET_TYPE_FOR_NON_VOID = "Bad return value";
	public static final String ARITH_OP_TO_NON_NUM = "Arithmetic operator applied to non-numeric operand";
	public static final String REL_OP_TO_NON_NUM = "Relational operator applied to non-numeric operand";
	public static final String LOG_OP_TO_NON_BOOL = "Logical operator applied to non-bool operand";
	public static final String NON_BOOL_EXP_IN_IF_COND = "Non-bool expression used as an if condition";
	public static final String NON_BOOL_EXP_IN_WHILE_COND = "Non-bool expression used as a while condition";
	//pplying an equality operator (==, !=) to operands of two different types (e.g., "j == true", 
	//where j is of type int), or assigning a value of one type
	// to a variable of another type
	// (e.g., "j = true", where j is of type int).
	public static final String TYPE_MISMATCH = "Type mismatch";
	public static final String EQ_OP_TO_VOID_FN = "Equality operator applied to void functions";
	public static final String EQ_OP_TO_FN = "Equality operator applied to functions";
	public static final String EQ_OP_TO_STRUCT_NAMES = "Equality operator applied to struct names";
	public static final String EQ_OP_TO_STRUCT_VARS = "Equality operator applied to struct variables";
	public static final String FN_ASSIGN = "Function assignment";
	public static final String STRUCT_NAME_ASSIGN = "Struct name assignment";
	public static final String STRUCT_VAR_ASSIGN = "Struct variable assignment";
}