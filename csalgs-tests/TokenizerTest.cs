using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csalgs.formula;
namespace csalgs_tests
{

    [TestClass]
    public class TokenizerTest
    {
        
        [TestMethod]
        public void TestInit() {
            ITokenizer tockenizer = GetTokenizer();
        }

        [TestMethod]
        public void TestEqual()
        {
            Token t1 = T(TokenType.PLUS, "+");
            Token t2 = T(TokenType.PLUS, "+");
            Assert.AreEqual(true, t1.Equals(t2));
			
        }

		[TestMethod]
		public void TestNotEqual()
		{
			Token t1 = T(TokenType.PLUS, "+");
			Token t2 = T(TokenType.EQUAL, "=");
			Assert.AreEqual(true, !t1.Equals(t2));
		}

        private ITokenizer GetTokenizer()
        {
            return new Tokenizer();
        }

        [TestMethod]
        public void TestTokens()
        {
			for(int i =0; i<250000; i++){
            Test("x=1+2", new Token[] { T(TokenType.IDENT, "x"), 
                                        T(TokenType.EQUAL, "="), 
                                        T(TokenType.NUMBER, "1"), 
                                        T(TokenType.PLUS, "+"), 
                                        T(TokenType.NUMBER, "2") });

            Test("x=y-2.3", new Token[] { T(TokenType.IDENT, "x"), 
                                        T(TokenType.EQUAL, "="), 
                                        T(TokenType.IDENT, "y"), 
                                        T(TokenType.MINUS, "-"), 
                                        T(TokenType.NUMBER, "2.3") });

            Test("x=fun(123.3+4^1)", new Token[] {  T(TokenType.IDENT, "x"), 
                                                    T(TokenType.EQUAL, "="), 
                                                    T(TokenType.IDENT, "fun"), 
                                                    T(TokenType.LEFT_BRACKET, "("), 
                                                    T(TokenType.NUMBER, "123.3"), 
                                                    T(TokenType.PLUS, "+"),
                                                    T(TokenType.NUMBER, "4"), 
                                                    T(TokenType.POWER, "^"),
                                                    T(TokenType.NUMBER, "1"), 
                                                    T(TokenType.RIGHT_BRACKET, ")") });
			}
        }

        private void Test(String expr, Token[] tokens) {
            ITokenizer tokenizer = GetTokenizer();
			Token[] actual = tokenizer.GetTokens(expr);
			int i  = 0;
			for(i =0; i<actual.Length; i++){
				Assert.IsTrue(tokens[i].Equals(actual[i]));
			}
            //Assert.AreEqual<Token[]>(tokens, actual);
        }

        private Token T(TokenType t, String s) {
            return new Token(t, s);
        }
    }
}
