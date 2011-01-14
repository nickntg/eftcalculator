Imports EFTCalculator.Core.PIN

<TestClass()>
Public Class PINBlockUnitTests

    <TestMethod()>
    Public Sub TestAnsiX98()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.AnsiX98, "1234", "", "5044070000253211")
        Assert.AreEqual("0412748FFFFDACDE", PB)
        Assert.AreEqual("1234", PinBlock.ToPIN(PinBlockFormat.AnsiX98, PB, "", "5044070000253211"))
    End Sub

    <TestMethod()>
    Public Sub TestDiebold()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.Diebold, "1234", "", "")
        Assert.AreEqual("1234FFFFFFFFFFFF", PB)
        Assert.AreEqual("1234", PinBlock.ToPIN(PinBlockFormat.Diebold, PB, "", ""))
    End Sub

    <TestMethod()>
    Public Sub TestDocutel()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.Docutel, "92389", "987654321", "")
        Assert.AreEqual("5923890987654321", PB)
        Assert.AreEqual("92389", PinBlock.ToPIN(PinBlockFormat.Docutel, PB, "987654321", ""))
    End Sub

    <TestMethod()>
    Public Sub TestIBM3621()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.IBM_3621, "2341", "F", "")
        Assert.AreEqual("12342341FFFFFFFF", PB)
        Assert.AreEqual("2341", PinBlock.ToPIN(PinBlockFormat.IBM_3621, PB, "F", ""))
    End Sub

    <TestMethod()>
    Public Sub TestIBM4704()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.IBM_4704, "1234", "", "")
        Assert.AreEqual("41234FFFFFFFFF12", PB)
        Assert.AreEqual("1234", PinBlock.ToPIN(PinBlockFormat.IBM_4704, PB, "", ""))
    End Sub

    <TestMethod()>
    Public Sub TestISO1()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.ISO_1, "1234", "", "")
        Assert.AreEqual("141234", PB.Substring(0, 6))
        Assert.AreEqual("1234", PinBlock.ToPIN(PinBlockFormat.ISO_1, PB, "", ""))
    End Sub

    <TestMethod()>
    Public Sub TestISO3()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.ISO_3, "1234", "", "4111111111111111 ")
        Assert.AreEqual("341225", PB.Substring(0, 6))
        Assert.AreEqual("1234", PinBlock.ToPIN(PinBlockFormat.ISO_3, PB, "", "4111111111111111 "))
    End Sub

    <TestMethod()>
    Public Sub TestPlus()
        Dim PB As String = PinBlock.ToPINBlock(PinBlockFormat.Plus, "92389", "", "2283400000123456")
        Assert.AreEqual("05921A1CBFFFFFED", PB)
        Assert.AreEqual("92389", PinBlock.ToPIN(PinBlockFormat.Plus, PB, "", "2283400000123456"))
    End Sub

End Class
