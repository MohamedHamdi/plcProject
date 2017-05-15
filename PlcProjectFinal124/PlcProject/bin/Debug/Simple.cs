
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_MINUSMINUS           =  4, // '--'
        SYMBOL_DOLLAR               =  5, // '$'
        SYMBOL_LPAREN               =  6, // '('
        SYMBOL_RPAREN               =  7, // ')'
        SYMBOL_TIMES                =  8, // '*'
        SYMBOL_TIMESEQ              =  9, // '*='
        SYMBOL_DIV                  = 10, // '/'
        SYMBOL_DIVEQ                = 11, // '/='
        SYMBOL_COLON                = 12, // ':'
        SYMBOL_CARET                = 13, // '^'
        SYMBOL_CARETCARET           = 14, // '^^'
        SYMBOL_LBRACE               = 15, // '{'
        SYMBOL_RBRACE               = 16, // '}'
        SYMBOL_PLUS                 = 17, // '+'
        SYMBOL_PLUSPLUS             = 18, // '++'
        SYMBOL_LT                   = 19, // '<'
        SYMBOL_LTEQ                 = 20, // '<='
        SYMBOL_EQ                   = 21, // '='
        SYMBOL_EQMINUS              = 22, // '=-'
        SYMBOL_EQTIMES              = 23, // '=*'
        SYMBOL_EQDIV                = 24, // '=/'
        SYMBOL_EQPLUS               = 25, // '=+'
        SYMBOL_EQEQ                 = 26, // '=='
        SYMBOL_GT                   = 27, // '>'
        SYMBOL_GTEQ                 = 28, // '>='
        SYMBOL_BACKWITH             = 29, // backWith
        SYMBOL_BY                   = 30, // By
        SYMBOL_CALL                 = 31, // call
        SYMBOL_CASE                 = 32, // case
        SYMBOL_CHAR                 = 33, // char
        SYMBOL_CHOOSER              = 34, // Chooser
        SYMBOL_CONTINUE             = 35, // continue
        SYMBOL_DEFAULT              = 36, // default
        SYMBOL_ELSE                 = 37, // else
        SYMBOL_FROM                 = 38, // From
        SYMBOL_FUNC                 = 39, // func
        SYMBOL_GOTOCOLON            = 40, // 'goto:'
        SYMBOL_GOUT                 = 41, // gout
        SYMBOL_IDENTIFIER           = 42, // identifier
        SYMBOL_IF                   = 43, // if
        SYMBOL_LOOP                 = 44, // Loop
        SYMBOL_NUMBER               = 45, // number
        SYMBOL_STRING               = 46, // string
        SYMBOL_TO                   = 47, // To
        SYMBOL_TYPE                 = 48, // type
        SYMBOL_WHILE                = 49, // While
        SYMBOL_ARTHIMETIC           = 50, // <arthimetic>
        SYMBOL_ARTHIMETICOP         = 51, // <arthimeticOp>
        SYMBOL_ARTHIMETICOPMULT     = 52, // <arthimeticOpMult>
        SYMBOL_ARTHIMETICOPNEGATE   = 53, // <arthimeticOpNegate>
        SYMBOL_ASSIGNMENT           = 54, // <Assignment>
        SYMBOL_BLOCK                = 55, // <block>
        SYMBOL_BLOCKS               = 56, // <blocks>
        SYMBOL_CALLMINUSSTMT        = 57, // <call-stmt>
        SYMBOL_CASEMINUSSTMT        = 58, // <case-stmt>
        SYMBOL_CASEMINUSSTMTS       = 59, // <case-stmts>
        SYMBOL_CONTROLMINUSSTMT     = 60, // <control-stmt>
        SYMBOL_FORMINUSSTMT         = 61, // <for-stmt>
        SYMBOL_FUNCTIONMINUSSTMT    = 62, // <function-stmt>
        SYMBOL_GENERALMINUSBLOCK    = 63, // <General-Block>
        SYMBOL_IDENTIFICATION       = 64, // <identification>
        SYMBOL_IDENTORASSIGN        = 65, // <identOrAssign>
        SYMBOL_IFMINUSSTMT          = 66, // <if-stmt>
        SYMBOL_INCREMENTORDECREMENT = 67, // <incrementOrDecrement>
        SYMBOL_LOGICALMINUSEXP      = 68, // <logical-exp>
        SYMBOL_NUMORSTRING          = 69, // <numOrString>
        SYMBOL_OPERATORS            = 70, // <operators>
        SYMBOL_PROGRAM              = 71, // <program>
        SYMBOL_STATEMENT            = 72, // <statement>
        SYMBOL_STATEMENTS           = 73, // <statements>
        SYMBOL_SWITCHMINUSSTMT      = 74, // <switch-stmt>
        SYMBOL_VALUE                = 75  // <value>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                                               =  0, // <program> ::= <blocks>
        RULE_BLOCKS                                                                                =  1, // <blocks> ::= <block>
        RULE_BLOCKS2                                                                               =  2, // <blocks> ::= <block> <blocks>
        RULE_BLOCK_IDENTIFIER_LBRACE_RBRACE                                                        =  3, // <block> ::= identifier '{' <statements> '}'
        RULE_GENERALBLOCK_LBRACE_RBRACE                                                            =  4, // <General-Block> ::= '{' <statements> '}'
        RULE_IDENTORASSIGN                                                                         =  5, // <identOrAssign> ::= <identification>
        RULE_IDENTORASSIGN2                                                                        =  6, // <identOrAssign> ::= <Assignment>
        RULE_NUMORSTRING_NUMBER                                                                    =  7, // <numOrString> ::= number
        RULE_NUMORSTRING_STRING                                                                    =  8, // <numOrString> ::= string
        RULE_STATEMENTS                                                                            =  9, // <statements> ::= <statement>
        RULE_STATEMENTS2                                                                           = 10, // <statements> ::= <statements> <statement>
        RULE_STATEMENT                                                                             = 11, // <statement> ::= <identification>
        RULE_STATEMENT2                                                                            = 12, // <statement> ::= <Assignment>
        RULE_STATEMENT_DOLLAR                                                                      = 13, // <statement> ::= <arthimetic> '$'
        RULE_STATEMENT_DOLLAR2                                                                     = 14, // <statement> ::= <for-stmt> '$'
        RULE_STATEMENT_DOLLAR3                                                                     = 15, // <statement> ::= <switch-stmt> '$'
        RULE_STATEMENT_DOLLAR4                                                                     = 16, // <statement> ::= <control-stmt> '$'
        RULE_STATEMENT_DOLLAR5                                                                     = 17, // <statement> ::= <if-stmt> '$'
        RULE_STATEMENT_DOLLAR6                                                                     = 18, // <statement> ::= <case-stmt> '$'
        RULE_STATEMENT_DOLLAR7                                                                     = 19, // <statement> ::= <identification> '$'
        RULE_STATEMENT_DOLLAR8                                                                     = 20, // <statement> ::= <function-stmt> '$'
        RULE_STATEMENT_DOLLAR9                                                                     = 21, // <statement> ::= <call-stmt> '$'
        RULE_STATEMENT_DOLLAR10                                                                    = 22, // <statement> ::= <incrementOrDecrement> '$'
        RULE_STATEMENT3                                                                            = 23, // <statement> ::= 
        RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_NUMBER_DOLLAR                                       = 24, // <identification> ::= type identifier '=' number '$'
        RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_CHAR_DOLLAR                                         = 25, // <identification> ::= type identifier '=' char '$'
        RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_STRING_DOLLAR                                       = 26, // <identification> ::= type identifier '=' string '$'
        RULE_IDENTIFICATION_TYPE_IDENTIFIER_CARET_EQ_NUMBER_DOLLAR                                 = 27, // <identification> ::= type identifier '^' '=' number '$'
        RULE_IDENTIFICATION_TYPE_IDENTIFIER_CARET_EQ_STRING_DOLLAR                                 = 28, // <identification> ::= type identifier '^' '=' string '$'
        RULE_IDENTIFICATION_TYPE_TYPE_IDENTIFIER_CARETCARET_EQ_NUMBER_STRING_DOLLAR                = 29, // <identification> ::= type type identifier '^^' '=' number string '$'
        RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_DOLLAR                                              = 30, // <identification> ::= type identifier '=' <arthimetic> '$'
        RULE_OPERATORS_PLUS                                                                        = 31, // <operators> ::= '+'
        RULE_OPERATORS_MINUS                                                                       = 32, // <operators> ::= '-'
        RULE_OPERATORS_TIMES                                                                       = 33, // <operators> ::= '*'
        RULE_OPERATORS_DIV                                                                         = 34, // <operators> ::= '/'
        RULE_OPERATORS_TIMESEQ                                                                     = 35, // <operators> ::= '*='
        RULE_OPERATORS_DIVEQ                                                                       = 36, // <operators> ::= '/='
        RULE_ASSIGNMENT_IDENTIFIER_EQ_STRING_DOLLAR                                                = 37, // <Assignment> ::= identifier '=' string '$'
        RULE_ASSIGNMENT_IDENTIFIER_EQ_NUMBER_DOLLAR                                                = 38, // <Assignment> ::= identifier '=' number '$'
        RULE_ASSIGNMENT_IDENTIFIER_EQ_CHAR_DOLLAR                                                  = 39, // <Assignment> ::= identifier '=' char '$'
        RULE_ASSIGNMENT_IDENTIFIER_EQ_DOLLAR                                                       = 40, // <Assignment> ::= identifier '=' <arthimetic> '$'
        RULE_ARTHIMETIC_PLUSPLUS                                                                   = 41, // <arthimetic> ::= <arthimetic> '++' <operators> <arthimeticOp>
        RULE_ARTHIMETIC_MINUSMINUS                                                                 = 42, // <arthimetic> ::= <arthimetic> '--' <operators> <arthimeticOp>
        RULE_ARTHIMETIC_TIMESEQ                                                                    = 43, // <arthimetic> ::= <arthimetic> '*=' <arthimeticOp>
        RULE_ARTHIMETIC_DIVEQ                                                                      = 44, // <arthimetic> ::= <arthimetic> '/=' <arthimeticOp>
        RULE_ARTHIMETIC                                                                            = 45, // <arthimetic> ::= <arthimeticOp>
        RULE_ARTHIMETICOP_PLUS                                                                     = 46, // <arthimeticOp> ::= <arthimeticOp> '+' <arthimeticOpMult>
        RULE_ARTHIMETICOP_MINUS                                                                    = 47, // <arthimeticOp> ::= <arthimeticOp> '-' <arthimeticOpMult>
        RULE_ARTHIMETICOP                                                                          = 48, // <arthimeticOp> ::= <arthimeticOpMult>
        RULE_ARTHIMETICOPMULT_DIV                                                                  = 49, // <arthimeticOpMult> ::= <arthimeticOpMult> '/' <arthimeticOpNegate>
        RULE_ARTHIMETICOPMULT_TIMES                                                                = 50, // <arthimeticOpMult> ::= <arthimeticOpMult> '*' <arthimeticOpNegate>
        RULE_ARTHIMETICOPMULT                                                                      = 51, // <arthimeticOpMult> ::= <arthimeticOpNegate>
        RULE_ARTHIMETICOPNEGATE_MINUS                                                              = 52, // <arthimeticOpNegate> ::= '-' <value>
        RULE_ARTHIMETICOPNEGATE                                                                    = 53, // <arthimeticOpNegate> ::= <value>
        RULE_VALUE_NUMBER                                                                          = 54, // <value> ::= number
        RULE_VALUE_IDENTIFIER                                                                      = 55, // <value> ::= identifier
        RULE_VALUE_LPAREN_RPAREN                                                                   = 56, // <value> ::= '(' <arthimetic> ')'
        RULE_INCREMENTORDECREMENT_IDENTIFIER_PLUSPLUS                                              = 57, // <incrementOrDecrement> ::= identifier '++'
        RULE_INCREMENTORDECREMENT_IDENTIFIER_MINUSMINUS                                            = 58, // <incrementOrDecrement> ::= identifier '--'
        RULE_LOGICALEXP_IDENTIFIER_EQEQ                                                            = 59, // <logical-exp> ::= identifier '==' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_LTEQ                                                            = 60, // <logical-exp> ::= identifier '<=' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_GTEQ                                                            = 61, // <logical-exp> ::= identifier '>=' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_LT                                                              = 62, // <logical-exp> ::= identifier '<' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_GT                                                              = 63, // <logical-exp> ::= identifier '>' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_EQPLUS                                                          = 64, // <logical-exp> ::= identifier '=+' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_EQMINUS                                                         = 65, // <logical-exp> ::= identifier '=-' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_EQTIMES                                                         = 66, // <logical-exp> ::= identifier '=*' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER_EQDIV                                                           = 67, // <logical-exp> ::= identifier '=/' <logical-exp>
        RULE_LOGICALEXP_IDENTIFIER                                                                 = 68, // <logical-exp> ::= identifier
        RULE_IFSTMT_IF_LPAREN_RPAREN_ELSE                                                          = 69, // <if-stmt> ::= if '(' <logical-exp> ')' <General-Block> else <General-Block>
        RULE_IFSTMT_IF_LPAREN_RPAREN                                                               = 70, // <if-stmt> ::= if '(' <logical-exp> ')' <General-Block>
        RULE_FORSTMT_LOOP_LPAREN_FROM_TO_BY_WHILE_RPAREN                                           = 71, // <for-stmt> ::= Loop '(' From <identOrAssign> To <identOrAssign> By <Assignment> While <logical-exp> ')' <General-Block>
        RULE_CASESTMTS                                                                             = 72, // <case-stmts> ::= <case-stmt>
        RULE_CASESTMTS2                                                                            = 73, // <case-stmts> ::= <case-stmts> <case-stmt>
        RULE_CASESTMT_CASE_COLON                                                                   = 74, // <case-stmt> ::= case ':' <General-Block>
        RULE_CASESTMT_DEFAULT_COLON                                                                = 75, // <case-stmt> ::= default ':' <General-Block>
        RULE_CONTROLSTMT_GOUT                                                                      = 76, // <control-stmt> ::= gout
        RULE_CONTROLSTMT_CONTINUE                                                                  = 77, // <control-stmt> ::= continue
        RULE_CONTROLSTMT_GOTOCOLON_IDENTIFIER                                                      = 78, // <control-stmt> ::= 'goto:' identifier
        RULE_CONTROLSTMT_IDENTIFIER_COLON                                                          = 79, // <control-stmt> ::= identifier ':'
        RULE_CONTROLSTMT_BACKWITH_IDENTIFIER                                                       = 80, // <control-stmt> ::= backWith identifier
        RULE_SWITCHSTMT_CHOOSER_LPAREN_IDENTIFIER_RPAREN_LBRACE_RBRACE                             = 81, // <switch-stmt> ::= Chooser '(' identifier ')' '{' <case-stmts> '}'
        RULE_FUNCTIONSTMT_FUNC_IDENTIFIER_LPAREN_IDENTIFIER_DOLLAR_IDENTIFIER_RPAREN_LBRACE_RBRACE = 82, // <function-stmt> ::= func identifier '(' identifier '$' identifier ')' '{' <statements> '}'
        RULE_CALLSTMT_CALL_IDENTIFIER_LPAREN_DOLLAR_RPAREN                                         = 83  // <call-stmt> ::= call identifier '(' <numOrString> '$' <numOrString> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOLLAR :
                //'$'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARETCARET :
                //'^^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQMINUS :
                //'=-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQTIMES :
                //'=*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQDIV :
                //'=/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQPLUS :
                //'=+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BACKWITH :
                //backWith
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BY :
                //By
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALL :
                //call
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHOOSER :
                //Chooser
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //continue
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM :
                //From
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //func
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOTOCOLON :
                //'goto:'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOUT :
                //gout
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //Loop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER :
                //number
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //To
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //type
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //While
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARTHIMETIC :
                //<arthimetic>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARTHIMETICOP :
                //<arthimeticOp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARTHIMETICOPMULT :
                //<arthimeticOpMult>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARTHIMETICOPNEGATE :
                //<arthimeticOpNegate>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCKS :
                //<blocks>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALLMINUSSTMT :
                //<call-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASEMINUSSTMT :
                //<case-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASEMINUSSTMTS :
                //<case-stmts>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTROLMINUSSTMT :
                //<control-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMINUSSTMT :
                //<for-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONMINUSSTMT :
                //<function-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GENERALMINUSBLOCK :
                //<General-Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFICATION :
                //<identification>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTORASSIGN :
                //<identOrAssign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFMINUSSTMT :
                //<if-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCREMENTORDECREMENT :
                //<incrementOrDecrement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALMINUSEXP :
                //<logical-exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMORSTRING :
                //<numOrString>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATORS :
                //<operators>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTS :
                //<statements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHMINUSSTMT :
                //<switch-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<value>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<program> ::= <blocks>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCKS :
                //<blocks> ::= <block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCKS2 :
                //<blocks> ::= <block> <blocks>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCK_IDENTIFIER_LBRACE_RBRACE :
                //<block> ::= identifier '{' <statements> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_GENERALBLOCK_LBRACE_RBRACE :
                //<General-Block> ::= '{' <statements> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTORASSIGN :
                //<identOrAssign> ::= <identification>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTORASSIGN2 :
                //<identOrAssign> ::= <Assignment>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMORSTRING_NUMBER :
                //<numOrString> ::= number
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMORSTRING_STRING :
                //<numOrString> ::= string
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS :
                //<statements> ::= <statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS2 :
                //<statements> ::= <statements> <statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <identification>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <Assignment>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR :
                //<statement> ::= <arthimetic> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR2 :
                //<statement> ::= <for-stmt> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR3 :
                //<statement> ::= <switch-stmt> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR4 :
                //<statement> ::= <control-stmt> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR5 :
                //<statement> ::= <if-stmt> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR6 :
                //<statement> ::= <case-stmt> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR7 :
                //<statement> ::= <identification> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR8 :
                //<statement> ::= <function-stmt> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR9 :
                //<statement> ::= <call-stmt> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DOLLAR10 :
                //<statement> ::= <incrementOrDecrement> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<statement> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_NUMBER_DOLLAR :
                //<identification> ::= type identifier '=' number '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_CHAR_DOLLAR :
                //<identification> ::= type identifier '=' char '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_STRING_DOLLAR :
                //<identification> ::= type identifier '=' string '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFICATION_TYPE_IDENTIFIER_CARET_EQ_NUMBER_DOLLAR :
                //<identification> ::= type identifier '^' '=' number '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFICATION_TYPE_IDENTIFIER_CARET_EQ_STRING_DOLLAR :
                //<identification> ::= type identifier '^' '=' string '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFICATION_TYPE_TYPE_IDENTIFIER_CARETCARET_EQ_NUMBER_STRING_DOLLAR :
                //<identification> ::= type type identifier '^^' '=' number string '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFICATION_TYPE_IDENTIFIER_EQ_DOLLAR :
                //<identification> ::= type identifier '=' <arthimetic> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORS_PLUS :
                //<operators> ::= '+'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORS_MINUS :
                //<operators> ::= '-'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORS_TIMES :
                //<operators> ::= '*'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORS_DIV :
                //<operators> ::= '/'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORS_TIMESEQ :
                //<operators> ::= '*='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORS_DIVEQ :
                //<operators> ::= '/='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ_STRING_DOLLAR :
                //<Assignment> ::= identifier '=' string '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ_NUMBER_DOLLAR :
                //<Assignment> ::= identifier '=' number '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ_CHAR_DOLLAR :
                //<Assignment> ::= identifier '=' char '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ_DOLLAR :
                //<Assignment> ::= identifier '=' <arthimetic> '$'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETIC_PLUSPLUS :
                //<arthimetic> ::= <arthimetic> '++' <operators> <arthimeticOp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETIC_MINUSMINUS :
                //<arthimetic> ::= <arthimetic> '--' <operators> <arthimeticOp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETIC_TIMESEQ :
                //<arthimetic> ::= <arthimetic> '*=' <arthimeticOp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETIC_DIVEQ :
                //<arthimetic> ::= <arthimetic> '/=' <arthimeticOp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETIC :
                //<arthimetic> ::= <arthimeticOp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOP_PLUS :
                //<arthimeticOp> ::= <arthimeticOp> '+' <arthimeticOpMult>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOP_MINUS :
                //<arthimeticOp> ::= <arthimeticOp> '-' <arthimeticOpMult>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOP :
                //<arthimeticOp> ::= <arthimeticOpMult>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOPMULT_DIV :
                //<arthimeticOpMult> ::= <arthimeticOpMult> '/' <arthimeticOpNegate>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOPMULT_TIMES :
                //<arthimeticOpMult> ::= <arthimeticOpMult> '*' <arthimeticOpNegate>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOPMULT :
                //<arthimeticOpMult> ::= <arthimeticOpNegate>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOPNEGATE_MINUS :
                //<arthimeticOpNegate> ::= '-' <value>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARTHIMETICOPNEGATE :
                //<arthimeticOpNegate> ::= <value>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_NUMBER :
                //<value> ::= number
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<value> ::= identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<value> ::= '(' <arthimetic> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INCREMENTORDECREMENT_IDENTIFIER_PLUSPLUS :
                //<incrementOrDecrement> ::= identifier '++'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INCREMENTORDECREMENT_IDENTIFIER_MINUSMINUS :
                //<incrementOrDecrement> ::= identifier '--'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_EQEQ :
                //<logical-exp> ::= identifier '==' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_LTEQ :
                //<logical-exp> ::= identifier '<=' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_GTEQ :
                //<logical-exp> ::= identifier '>=' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_LT :
                //<logical-exp> ::= identifier '<' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_GT :
                //<logical-exp> ::= identifier '>' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_EQPLUS :
                //<logical-exp> ::= identifier '=+' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_EQMINUS :
                //<logical-exp> ::= identifier '=-' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_EQTIMES :
                //<logical-exp> ::= identifier '=*' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER_EQDIV :
                //<logical-exp> ::= identifier '=/' <logical-exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXP_IDENTIFIER :
                //<logical-exp> ::= identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_LPAREN_RPAREN_ELSE :
                //<if-stmt> ::= if '(' <logical-exp> ')' <General-Block> else <General-Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_LPAREN_RPAREN :
                //<if-stmt> ::= if '(' <logical-exp> ')' <General-Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSTMT_LOOP_LPAREN_FROM_TO_BY_WHILE_RPAREN :
                //<for-stmt> ::= Loop '(' From <identOrAssign> To <identOrAssign> By <Assignment> While <logical-exp> ')' <General-Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASESTMTS :
                //<case-stmts> ::= <case-stmt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASESTMTS2 :
                //<case-stmts> ::= <case-stmts> <case-stmt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASESTMT_CASE_COLON :
                //<case-stmt> ::= case ':' <General-Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASESTMT_DEFAULT_COLON :
                //<case-stmt> ::= default ':' <General-Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONTROLSTMT_GOUT :
                //<control-stmt> ::= gout
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONTROLSTMT_CONTINUE :
                //<control-stmt> ::= continue
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONTROLSTMT_GOTOCOLON_IDENTIFIER :
                //<control-stmt> ::= 'goto:' identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONTROLSTMT_IDENTIFIER_COLON :
                //<control-stmt> ::= identifier ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONTROLSTMT_BACKWITH_IDENTIFIER :
                //<control-stmt> ::= backWith identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTMT_CHOOSER_LPAREN_IDENTIFIER_RPAREN_LBRACE_RBRACE :
                //<switch-stmt> ::= Chooser '(' identifier ')' '{' <case-stmts> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONSTMT_FUNC_IDENTIFIER_LPAREN_IDENTIFIER_DOLLAR_IDENTIFIER_RPAREN_LBRACE_RBRACE :
                //<function-stmt> ::= func identifier '(' identifier '$' identifier ')' '{' <statements> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CALLSTMT_CALL_IDENTIFIER_LPAREN_DOLLAR_RPAREN :
                //<call-stmt> ::= call identifier '(' <numOrString> '$' <numOrString> ')'
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //todo: Use your fully reduced args.Token.UserObject
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }


    }
}
