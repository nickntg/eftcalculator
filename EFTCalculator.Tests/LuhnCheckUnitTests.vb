Imports EFTCalculator.Core

<TestClass()>
Public Class LuhnCheckUnitTests

    <TestMethod()>
    Public Sub TestLuhnCheck()
        Assert.AreEqual("5", Utility.LuhnCheck("378282246310005"))
        Assert.AreEqual("1", Utility.LuhnCheck("371449635398431"))
        Assert.AreEqual("0", Utility.LuhnCheck("378734493671000"))
        Assert.AreEqual("0", Utility.LuhnCheck("5610591081018250"))
        Assert.AreEqual("4", Utility.LuhnCheck("30569309025904"))
        Assert.AreEqual("7", Utility.LuhnCheck("38520000023237"))
        Assert.AreEqual("7", Utility.LuhnCheck("6011111111111117"))
        Assert.AreEqual("4", Utility.LuhnCheck("6011000990139424"))
        Assert.AreEqual("0", Utility.LuhnCheck("3530111333300000"))
        Assert.AreEqual("5", Utility.LuhnCheck("3566002020360505"))
        Assert.AreEqual("4", Utility.LuhnCheck("5555555555554444"))
        Assert.AreEqual("0", Utility.LuhnCheck("5105105105105100"))
        Assert.AreEqual("1", Utility.LuhnCheck("4111111111111111"))
        Assert.AreEqual("1", Utility.LuhnCheck("4012888888881881"))
        Assert.AreEqual("2", Utility.LuhnCheck("4222222222222"))
        Assert.AreEqual("2", Utility.LuhnCheck("5019717010103742"))
        Assert.AreEqual("6", Utility.LuhnCheck("6331101999990016"))
    End Sub

End Class
