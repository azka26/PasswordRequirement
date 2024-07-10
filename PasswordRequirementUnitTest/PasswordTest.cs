using FluentAssertions;
using PasswordRequirement;

namespace PasswordRequirementUnitTest;

public class PasswordTest
{
    private static class ErrorList
    {
        public static readonly string CombinationLetterAndNumber = "Password should contains combination letter and number.";
        public static readonly string CombinationLowerAndUpper = "Password should contains combination lower and upper case.";
        public static readonly string PasswordLength = "Minimum password length should be 8 character.";
        public static readonly  string SpecialCharacter =
            @"Password should contains special character = [\[\]~!@#$%^&*\-+_=?><].";
    }
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Invalid_Test()
    {
        var verificator = new DefaultPasswordVeficator();
        var result = verificator.Verify("error");
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.PasswordLength);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public void ValidCombinationLetterAndNumber_Test()
    {
        var verificator = new DefaultPasswordVeficator();
        var result = verificator.Verify("error1");
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.PasswordLength);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public void ValidCombinationLowerAndUpper_Test()
    {
        var verificator = new DefaultPasswordVeficator();
        var result = verificator.Verify("errorE");
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.PasswordLength);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public void ValidLength_Test()
    {
        var verificator = new DefaultPasswordVeficator();
        var result = verificator.Verify("abcdefgh");
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public void ValidSpecialCharacter_Test()
    {
        var verificator = new DefaultPasswordVeficator();
        var result = verificator.Verify("@bcd");
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.PasswordLength);
    }
    
    [Test]
    public void Valid_Test()
    {
        var verificator = new DefaultPasswordVeficator();
        var result = verificator.Verify("MyPassword@123");
        result.Should().HaveCount(0);
    }
}