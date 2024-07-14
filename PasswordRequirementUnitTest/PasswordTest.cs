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
    public async Task Invalid_Test()
    {
        var verificator = new DefaultPasswordVerifierService();
        var result = await verificator.VerifyAsync(new UserData("error"));
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.PasswordLength);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public async Task ValidCombinationLetterAndNumber_Test()
    {
        var verificator = new DefaultPasswordVerifierService();
        var result = await verificator.VerifyAsync(new UserData("error1"));
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.PasswordLength);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public async Task ValidCombinationLowerAndUpper_Test()
    {
        var verificator = new DefaultPasswordVerifierService();
        var result = await verificator.VerifyAsync(new UserData("errorE"));
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.PasswordLength);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public async Task ValidLength_Test()
    {
        var verificator = new DefaultPasswordVerifierService();
        var result = await verificator.VerifyAsync(new UserData("abcdefgh"));
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.SpecialCharacter);
    }
    
    [Test]
    public async Task ValidSpecialCharacter_Test()
    {
        var verificator = new DefaultPasswordVerifierService();
        var result = await verificator.VerifyAsync(new UserData("@bcd"));
        result.Should().Contain(ErrorList.CombinationLetterAndNumber);
        result.Should().Contain(ErrorList.CombinationLowerAndUpper);
        result.Should().Contain(ErrorList.PasswordLength);
    }
    
    [Test]
    public async Task Valid_Test()
    {
        var verificator = new DefaultPasswordVerifierService();
        var result = await verificator.VerifyAsync(new UserData("MyPassword@123"));
        result.Should().HaveCount(0);
    }
}