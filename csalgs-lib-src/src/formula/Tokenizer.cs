using System;
using System.Collections.Generic;
using System.Globalization;

namespace csalgs.formula
{
	public class TokenizerError : Exception
	{
		private String buffer;
		private int index;

		public TokenizerError(String text, String buffer, int index)
			: base(text)
		{
			this.buffer = buffer;
			this.index = index;
		}

		public String Buffer
		{
			get
			{
				return this.buffer;
			}
		}

		public int Index
		{
			get
			{
				return this.index;
			}
		}

	}

    public enum TokenType:int {
		WHITE = -2,
		UNKNOWN = -1,
        NUMBER = 0, 
        PLUS=1, MINUS=2, PRODUCT=3, DIVISION=4, EQUAL=5,
        POWER=6,
        IDENTIFIER=7,
        DOT=8, COMMA=9,
        LEFT_BRACKET=10, RIGHT_BRACKET=11
    }

    public class Token
    {
        private String value;
        private TokenType type;
		private int index;

        public Token(TokenType type, String value, int index) {
            this.type = type;
            this.value = value;
			this.index = index;
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

		public int Index{
			get{
				return index;
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

		public override string ToString()
		{
			return "Token(" + Type + ", " +Value + ")";
		}
    }

    public interface ITokenizer {
        Token[] GetTokens(String expression);
		Boolean IgnoreWhites{
			get;
			set;
		}
    }

    public sealed class Tokenizer:ITokenizer {

		private const String IDENT_SYMBOLS = "0987654321qwertyuiopasdfghjklzxcvbnm_QWERTYUIOPASDFGHJKLZXCVBNM";
		private const String NUMBER_SYMBOLS = "0987654321.";
		private const String OPERATIONS = "=+-/*^";
		private const String BRACKETS = "()";
		private const String WHITES = " \t";
		private const String COMMA = ",";
		
		private delegate void commit(char currentChar, String buffer, int index, List<Token> tokens);
		private delegate bool checkChar(char cc);

		private bool ignoreWhites = true;

		private NumberStyles numberStyles = NumberStyles.Any;
		private IFormatProvider formatProvider = CultureInfo.GetCultureInfo("en-US");

		public Tokenizer() { }

        public Token[] GetTokens(String expression)
        {
            List<Token> tokens = new List<Token>();
			
            int length = expression.Length;
			int index = 0;

            char currentChar = ' ';
            string buffer = "";
			commit whites;

			if(IgnoreWhites){
				whites = WhitesCommitWithIgnoring;
			}else{
				whites = WhitesCommit;
			}

			checkChar currentChecker = null;
			commit currentCommiter = null;

			for (index = 0; index < length; index++) {
				currentChar = expression[index];

				#region Start
				if(currentChecker==null || currentCommiter==null){
					if (IsNumberChar(currentChar)){
						currentChecker = IsNumberChar;
						currentCommiter = NumberCommit;
					}
					else if (IsIdentifierChar(currentChar))
					{
						currentChecker = IsIdentifierChar;
						currentCommiter = IdentifierCommit;
					}
					else if (IsOperationChar(currentChar))
					{
						currentChecker = IsOperationChar;
						currentCommiter = OperationsCommit;
					}
					else if (IsBracketsChar(currentChar))
					{
						currentChecker = IsBracketsChar;
						currentCommiter = BracketsCommit;
					}
					else if (IsWhites(currentChar))
					{
						currentChecker = IsWhites;
						currentCommiter = whites;
					}
					else if (IsCommaChar(currentChar))
					{
						currentChecker = IsCommaChar;
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
					
					currentCommiter(currentChar, buffer, index - buffer.Length, tokens);

					index--;
					buffer = "";
					currentChecker = null;
					currentCommiter = null;
				}
			}

			if(currentChecker!=null && currentCommiter!=null && buffer.Length>0){
				currentCommiter(currentChar, buffer, index, tokens);
			}

			return tokens.ToArray();
        }

		private void NumberCommit(char currentChar, String buffer, int index, List<Token> tokens){
			double number;
			if(!double.TryParse(buffer, numberStyles, formatProvider, out number)){
				Error(index, buffer, "Incorrect number format");
			}
			tokens.Add(new Token(TokenType.NUMBER, buffer, index));
		}

		private void WhitesCommit(char currentChar, String buffer, int index, List<Token> tokens){
			tokens.Add(new Token(TokenType.WHITE, buffer, index));
		}

		private void WhitesCommitWithIgnoring(char currentChar, String buffer, int index, List<Token> tokens)
		{
			//ignoring
		}
			
		private void IdentifierCommit(char currentChar, String buffer, int index, List<Token> tokens){
			tokens.Add(new Token(TokenType.IDENTIFIER, buffer, index));
		}
			
		private void BracketsCommit(char currentChar, String buffer, int index, List<Token> tokens){
			TokenType tempTokenType;
			for(int i = 0; i<buffer.Length; i++){
				tempTokenType = GetBracketsTokenTypeByValue(buffer[i].ToString());
				if(tempTokenType == TokenType.UNKNOWN){
					Error(index, buffer[i].ToString(), "Unknown token when reading braces");
				}
				tokens.Add(new Token(tempTokenType, buffer[i].ToString(), index));
			}
		}

		private void OperationsCommit(char currentChar, String buffer, int index, List<Token>tokens){
			TokenType tempTokenType;
			
			for (int i = 0; i < buffer.Length; i++)
			{
				tempTokenType = GetOperationTokenTypeByValue(buffer[i].ToString());
				if (tempTokenType == TokenType.UNKNOWN)
				{
					Error(index, buffer[i].ToString(), "Unknown token when reading operations");
				}
				tokens.Add(new Token(tempTokenType, buffer[i].ToString(), index));
			}
		}

		private void CommaCommit(char currentChar, String buffer, int index, List<Token>tokens){
			for (int i = 0; i < buffer.Length; i++)
			{
				tokens.Add(new Token(TokenType.COMMA, buffer[i].ToString(), index));
			}
		}

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
            return -1 != WHITES.IndexOf(c);
        }

		private bool IsIdentifierChar(char c)
		{
            return -1 != IDENT_SYMBOLS.IndexOf(c);
        }

		private bool IsNumberChar(char c)
        {
            return -1 != NUMBER_SYMBOLS.IndexOf(c);
        }

		private bool IsOperationChar(char c)
        {
            return -1 != OPERATIONS.IndexOf(c);
        }

		private bool IsBracketsChar(char c)
        {
            return -1 != BRACKETS.IndexOf(c);
        }

		private bool IsCommaChar(char c)
        {
            return -1 != COMMA.IndexOf(c);
        }

		private void Error(int index, String buffer, String text)
		{
            throw new TokenizerError(text, buffer, index);
        }

		public bool IgnoreWhites
		{
			get
			{
				return ignoreWhites;
			}
			set
			{
				ignoreWhites = value;
			}
		}
	}
}
