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
			Test("1+2+3+4 +5 - 10 * fff(123123+ff()+gg(1,2)");
            Test("x=1+2");
            Test("x=y-2.3");
            Test(" x= fun(123.3 + 4^1)^ ( 123 +x* sin(PI))");
        }

		private void Test(String expr)
		{
			ITokenizer tokenizer = GetTokenizer();
			Token[] actual = tokenizer.GetTokens(expr);
			string actualString="";

			for(int i = 0; i< actual.Length; i++){
				actualString+=actual[i].Value;
			}

			Assert.AreEqual<string>(expr, actualString);
		}

        private Token T(TokenType t, String s) {
            return new Token(t, s);
        }
    }
}
