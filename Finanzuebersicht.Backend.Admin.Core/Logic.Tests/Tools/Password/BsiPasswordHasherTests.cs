﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Password;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Tools.Password
{
    [TestClass]
    public class BsiPasswordHasherTests
    {
        [TestMethod]
        public void GetPasswordHashAndSalt()
        {
            // Arrange
            string password = ")Test&Password123(";
            BsiPasswordHasher bsiPasswordHasher = new BsiPasswordHasher();

            // Act
            IBsiPasswordHash passwordHash = bsiPasswordHasher.HashPassword(password);
            IBsiPasswordHash passwordHash2 = bsiPasswordHasher.HashPassword(password);

            // Assert
            Assert.AreNotEqual(passwordHash.PasswordHash, passwordHash2.PasswordHash);
            Assert.AreNotEqual(passwordHash.Salt, passwordHash2.Salt);
        }

        [TestMethod]
        public void GetPasswordHashOfSalt()
        {
            // Arrange
            string password = ")Test&Password123(";
            string salt = "50000.lrqV9R0IfJiFGjQN1wQvTIlhCPYAwgFS+7WjcjsAjAO/1g==";
            BsiPasswordHasher bsiPasswordHasher = new BsiPasswordHasher();

            // Act
            IBsiPasswordHash passwordHash = bsiPasswordHasher.HashPassword(password, salt);

            // Assert
            string hash = "dsrVUMMTclkN6d5xky/3/M2ervMlIvPByFA/g7LuORGLl1K6O0oXvKqmN+0/nakTqDhSUu3+tCKrSm8RXNkEng==";

            Assert.AreEqual(hash, passwordHash.PasswordHash);
            Assert.AreEqual(salt, passwordHash.Salt);
        }

        [TestMethod]
        public void ComparePasswords()
        {
            // Arrange
            string password = ")Test&Password123(";
            BsiPasswordHasher bsiPasswordHasher = new BsiPasswordHasher();
            IBsiPasswordHash passwordHash = bsiPasswordHasher.HashPassword(password);

            // Act
            bool isValid = bsiPasswordHasher.ComparePasswords(password, passwordHash.PasswordHash, passwordHash.Salt);

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}