using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class DialogBoxTest {

	private DialogBoxWriter dialogBoxWriter;

	[SetUp]
	public void Init() {
		dialogBoxWriter = new DialogBoxWriter ();
		dialogBoxWriter.SetUITextPrinter (GetMockTextPrinter ());
	}

	[Test]
	[ExpectedException(typeof(IllegalStateException))]
	public void TestPrint_NoTextThrowsException() {
		dialogBoxWriter.Print ();
	}

	[Test]
	public void TestHasMoreText_ReturnsFalseIfNoTextSet() {
		Assert.IsFalse(dialogBoxWriter.HasMoreText ());
	}

	[Test]
	public void TestHasMoreText_ReturnsFalseIfTextIsEmpty() {
		dialogBoxWriter.SetText("");
		Assert.IsFalse(dialogBoxWriter.HasMoreText ());
	}

	[Test]
	public void TestHasMoreText_ReturnsTrueIfTextIsNotEmpty() {
		dialogBoxWriter.SetText("Kyle");
		Assert.IsTrue(dialogBoxWriter.HasMoreText ());
	}

	[Test]
	public void TestPrint_PrintsOneCharacter() {
		dialogBoxWriter.SetText("Kyle");
		dialogBoxWriter.Print ();
		Assert.IsTrue(dialogBoxWriter.HasMoreText ());
	}

	[Test]
	public void TestHasMoreText_IsFalseAfterPrintHasFinished() {
		dialogBoxWriter.SetText("Ky");
		dialogBoxWriter.Print ();
		dialogBoxWriter.Print ();
		Assert.IsFalse(dialogBoxWriter.HasMoreText ());
	}
		
	private IUITextPrinter GetMockTextPrinter() {
		return NSubstitute.Substitute.For<IUITextPrinter> ();
	}
}
