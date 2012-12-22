using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.formula
{
    public enum TokenType:int {
		UNKNOWN = -1,
        NUMBER = 0, 
        PLUS=1, MINUS=2, PRODUCT=3, DIVISION=4, EQUAL=5,
        POWER=6,
        IDENT=7,
        DOT=8, COMMA=9,
        LEFT_BRACKET=10, RIGHT_BRACKET=11//, LEFT_SQUARE_BRACKET=12, RIGHT_SQUARE_BRACKET=13
    }

    public class Token
    {
        private String value;
        private TokenType type;

        public Token(TokenType type, String value) {
            this.type = type;
            this.value = value;
        }

        public String Value {
            get {
                return value;
            }
        }

        public TokenType Type {
            get {
                return type;
            }
        }

        public override bool Equals(object obj)
        {
            Token inp = (obj as Token);
            return inp.Type == Type && inp.Value == (Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ (int)Type;
        }
    }

    public interface ITokenizer {
        Token[] GetTokens(String expression);
    }

    /*public enum TokenizerReadingState {
        START, OPERATION, NUMBER, IDENT, BRACKETS, COMMA, WHITES, ERROR
    }*/

    public sealed class Tokenizer:ITokenizer {
        public Tokenizer() {}

		private const String IDENT_SYMBOLS = "0987654321qwertyuiopasdfghjklzxcvbnm_QWERTYUIOPASDFGHJKLZXCVBNM";
		private const String NUMBER_SYMBOLS = "0987654321.";
		private const String OPERATIONS = "=+-/*^";
		private const String BRACKETS = "()";
		private const String WHITES = " \t";
		private const String COMMA = ",";
		
		private delegate void commit();
		
		private delegate bool checkChar(char cc);


        public Token[] GetTokens(String expression)
        {
            List<Token> tokens = new List<Token>();
			
			const int NOT_FIND = -1;

            int length = expression.Length;
			int lastIndex = length - 1;
			TokenType tempTokenType;
            char currentChar = ' ';
            string buffer = "";

			int index = 0;

			checkChar NumberChecker = IsNumberChar;//()=>{return NUMBER_SYMBOLS.IndexOf(currentChar)!=NOT_FIND;};
			checkChar WhitesChecker = IsWhites;//()=>{return WHITES.IndexOf(currentChar)!=NOT_FIND;};
			checkChar IdentifierChecker = IsIdentifierChar;//()=>{return IDENT_SYMBOLS.IndexOf(currentChar)!=NOT_FIND;};
			checkChar BracketsChecker = IsBracketsChar;//()=>{return BRACKETS.IndexOf(currentChar)!=NOT_FIND;};
			checkChar OperationsChecker = IsOperationChar;//()=>{return OPERATIONS.IndexOf(currentChar)!=NOT_FIND;};
			checkChar CommaChecker = IsCommaChar;//()=>{return COMMA.IndexOf(currentChar)!=NOT_FIND;};

			commit NumberCommit = ()=>{tokens.Add(new Token(TokenType.NUMBER, buffer));};
			
			commit WhitesCommit = ()=>{};
			
			commit IdentifierCommit = ()=>{tokens.Add(new Token(TokenType.IDENT, buffer));};
			
			commit BracketsCommit = ()=>{
				tempTokenType = GetBracketsTokenTypeByValue(buffer);
				if(tempTokenType == TokenType.UNKNOWN){
					Error(index, buffer, "Unknown token when reading braces");
				}
				tokens.Add(new Token(tempTokenType, buffer));
			};

			commit OperationsCommit = ()=>{
				tempTokenType = GetOperationTokenTypeByValue(buffer);
				if (tempTokenType == TokenType.UNKNOWN)
				{
					Error(index, buffer, "Unknown token when reading operations");
				}
				tokens.Add(new Token(tempTokenType, buffer));
			};

			commit CommaCommit = () => {tokens.Add(new Token(TokenType.COMMA, buffer));};

			checkChar currentChecker = null;
			commit currentCommiter = null;

			for (index = 0; index < length; index++) {
				currentChar = expression[index];
				#region Start
				if(currentChecker==null || currentCommiter==null){
					if (NumberChecker(currentChar)){
						currentChecker = NumberChecker;
						currentCommiter = NumberCommit;
					}
					else if (IdentifierChecker(currentChar))
					{
						currentChecker = IdentifierChecker;
						currentCommiter = IdentifierCommit;
					}
					else if (OperationsChecker(currentChar))
					{
						currentChecker = OperationsChecker;
						currentCommiter = OperationsCommit;
					}
					else if (BracketsChecker(currentChar))
					{
						currentChecker = BracketsChecker;
						currentCommiter = BracketsCommit;
					}
					else if (WhitesChecker(currentChar))
					{
						currentChecker = WhitesChecker;
						currentCommiter = WhitesCommit;
					}
					else if (CommaChecker(currentChar))
					{
						currentChecker = CommaChecker;
						currentCommiter = CommaCommit;
					}

					if(currentChecker==null || currentCommiter==null){
						Error(index, buffer, "Unknown char='" + currentChar + "'");	
					}
					
					index--;
					continue;
				}
				#endregion

				if (currentChecker(currentChar))
				{
					buffer+=currentChar;
				}else{
					
					currentCommiter();

					index--;
					buffer = "";
					currentChecker = null;
					currentCommiter = null;
				}
			}

			if(currentChecker!=null && currentCommiter!=null && buffer.Length>0){
				currentCommiter();
			}

			return tokens.ToArray();
        }

		/*protected TokenizerReadingState GetStateByChar(char currentChar)
		{
            if (IsNumberChar(currentChar)) return TokenizerReadingState.NUMBER;
            if (IsIdentifierChar(currentChar))return TokenizerReadingState.IDENT;
            if (IsOperationChar(currentChar))return TokenizerReadingState.OPERATION;
            if(IsBracketsChar(currentChar))return TokenizerReadingState.BRACKETS;
            if(IsWhites(currentChar))return TokenizerReadingState.WHITES;
            if (IsCommaChar(currentChar)) return TokenizerReadingState.COMMA;

            return TokenizerReadingState.ERROR;
        }*/

		private TokenType GetOperationTokenTypeByValue(String value)
		{
			switch(value){
				case "+":
					return TokenType.PLUS;

				case "-":
					return TokenType.MINUS;

				case "*":
					return TokenType.PRODUCT;

				case "/":
					return TokenType.DIVISION;

				case "^":
					return TokenType.POWER;

				case "=":
					return TokenType.EQUAL;

			}
			return TokenType.UNKNOWN;
		}

		private TokenType GetBracketsTokenTypeByValue(String value)
		{
			switch (value)
			{
				case "(":
					return TokenType.LEFT_BRACKET;

				case ")":
					return TokenType.RIGHT_BRACKET;
			}
			return TokenType.UNKNOWN;
		}

		private bool IsWhites(char c)
		{
            return -1!= WHITES.IndexOf(c);// CheckCharInAlphabet(c, WHITES);
        }

		private bool IsIdentifierChar(char c)
		{
            return -1!= IDENT_SYMBOLS.IndexOf(c);// CheckCharInAlphabet(c, IDENT_SYMBOLS);
        }

		private bool IsNumberChar(char c)
        {
            return -1!=NUMBER_SYMBOLS.IndexOf(c);//CheckCharInAlphabet(c, NUMBER_SYMBOLS);
        }

		private bool IsOperationChar(char c)
        {
            return -1!= OPERATIONS.IndexOf(c);// CheckCharInAlphabet(c, OPERATIONS);
        }

		private bool IsBracketsChar(char c)
        {
            return -1!= BRACKETS.IndexOf(c);// CheckCharInAlphabet(c, BRACKETS);
        }

		private bool IsCommaChar(char c)
        {
            return -1!=COMMA.IndexOf(c);//CheckCharInAlphabet(c, COMMA);
        }

		private bool CheckCharInAlphabet(char c, String alphabet)
		{
            return alphabet.IndexOf(c) != -1;
        }

		private void Error(int index, String buffer, String text)
		{
            throw new TokenizerError(text, buffer, index);
        }
    }

    public class TokenizerError:Exception{
        public TokenizerError(String text, String buffer, int index) : base(text) {
            
        }
    }


}
