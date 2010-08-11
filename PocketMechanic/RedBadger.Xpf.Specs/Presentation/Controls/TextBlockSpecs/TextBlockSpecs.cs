//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.TextBlockSpecs
{
    using Machine.Specifications;

    using Microsoft.Xna.Framework;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Media;

    using It = Machine.Specifications.It;

    public abstract class a_TextBlock
    {
        protected static Mock<IDrawingContext> DrawingContext;

        protected static Mock<RootElement> RootElement;

        protected static Mock<ISpriteFont> SpriteFont;

        protected static TextBlock TextBlock;

        private Establish context = () =>
            {
                var renderer = new Mock<IRenderer>();
                DrawingContext = new Mock<IDrawingContext>();
                renderer.Setup(r => r.GetDrawingContext(Moq.It.IsAny<IElement>())).Returns(DrawingContext.Object);

                RootElement = new Mock<RootElement>(renderer.Object, new Rect(new Size(100, 100))) { CallBase = true };
                SpriteFont = new Mock<ISpriteFont>();
                TextBlock = new TextBlock(SpriteFont.Object);
                RootElement.Object.Content = TextBlock;
            };
    }

    public abstract class a_Measured_and_Arranged_TextBlock : a_TextBlock
    {
        private Establish context = () => RootElement.Object.Update();
    }

    [Subject(typeof(TextBlock), "Foreground")]
    public class when_foreground_is_not_specified : a_TextBlock
    {
        private Because of = () => RootElement.Object.Update();

        private It should_default_to_black =
            () =>
            DrawingContext.Verify(
                drawingContext =>
                drawingContext.DrawText(
                    SpriteFont.Object, 
                    Moq.It.IsAny<string>(), 
                    Moq.It.IsAny<Vector2>(), 
                    Moq.It.Is<SolidColorBrush>(value => value.Color == Color.Black)));
    }

    [Subject(typeof(TextBlock), "Foreground")]
    public class when_foreground_is_specified : a_TextBlock
    {
        private static readonly SolidColorBrush expectedForeground = new SolidColorBrush(Color.White);

        private Because of = () =>
            {
                TextBlock.Foreground = expectedForeground;
                RootElement.Object.Update();
                RootElement.Object.Draw();
            };

        private It should_use_the_color_specified =
            () =>
            DrawingContext.Verify(
                drawingContext =>
                drawingContext.DrawText(
                    SpriteFont.Object, Moq.It.IsAny<string>(), Moq.It.IsAny<Vector2>(), expectedForeground));
    }

    [Subject(typeof(TextBlock), "Background")]
    public class when_textblock_background_is_not_specified : a_TextBlock
    {
        private Because of = () =>
            {
                RootElement.Object.Update();
                RootElement.Object.Draw();
            };

        private It should_not_render_a_background =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(Moq.It.IsAny<Rect>(), Moq.It.IsAny<Brush>()), 
                Times.Never());
    }

    [Subject(typeof(TextBlock), "Background")]
    public class when_textblock_background_is_specified : a_TextBlock
    {
        private static readonly SolidColorBrush expectedBackground = new SolidColorBrush(Color.Blue);

        private Because of = () =>
            {
                TextBlock.Background = expectedBackground;
                RootElement.Object.Update();
                RootElement.Object.Draw();
            };

        private It should_render_the_background_in_the_right_place = () =>
            {
                var area = new Rect(0, 0, TextBlock.ActualWidth, TextBlock.ActualHeight);

                DrawingContext.Verify(
                    drawingContext =>
                    drawingContext.DrawRectangle(Moq.It.Is<Rect>(rect => rect.Equals(area)), Moq.It.IsAny<Brush>()));
            };

        private It should_render_with_the_specified_background_color =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(Moq.It.IsAny<Rect>(), expectedBackground));
    }

    [Subject(typeof(TextBlock), "Padding")]
    public class when_padding_is_specified : a_TextBlock
    {
        private static readonly Size expectedDesiredSize = new Size(50, 70);

        private static readonly Vector2 expectedDrawPosition = new Vector2(10, 20);

        private static readonly Thickness padding = new Thickness(10, 20, 30, 40);

        private static readonly Vector2 stringSize = new Vector2(10, 10);

        private Establish context = () =>
            {
                TextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                TextBlock.VerticalAlignment = VerticalAlignment.Top;
                SpriteFont.Setup(font => font.MeasureString(Moq.It.IsAny<string>())).Returns(stringSize);
            };

        private Because of = () =>
            {
                TextBlock.Padding = padding;
                RootElement.Object.Update();
                RootElement.Object.Draw();
            };

        private It should_increase_the_desired_size = () => TextBlock.DesiredSize.ShouldEqual(expectedDesiredSize);

        private It should_take_padding_into_account_when_drawing =
            () =>
            DrawingContext.Verify(
                drawingContext =>
                drawingContext.DrawText(
                    SpriteFont.Object, Moq.It.IsAny<string>(), expectedDrawPosition, Moq.It.IsAny<Brush>()));
    }

    public abstract class a_TextBlock_With_Content : a_TextBlock
    {
        protected const string Space = " ";

        protected const string Word = "word";

        protected static readonly Vector2 SentenceSize = new Vector2(310, 10);

        private const string Sentence =
            Word + Space + Word + Space + Word + Space + Word + Space + Word + Space + Word + Space + Word;

        private Establish context = () =>
            {
                SpriteFont.Setup(font => font.MeasureString(Sentence)).Returns(SentenceSize);
                SpriteFont.Setup(font => font.MeasureString(Word)).Returns(new Vector2(40, 10));
                SpriteFont.Setup(font => font.MeasureString(Space)).Returns(new Vector2(5, 10));

                TextBlock.Text = Sentence;
            };
    }

    [Subject(typeof(TextBlock), "Padding")]
    public class when_padding_is_changed : a_Measured_and_Arranged_TextBlock
    {
        private Because of = () => TextBlock.Padding = new Thickness(10, 20, 30, 40);

        private It should_invalidate_arrange = () => TextBlock.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => TextBlock.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(TextBlock))]
    public class when_text_is_changed : a_Measured_and_Arranged_TextBlock
    {
        private Because of = () => TextBlock.Text = "new value";

        private It should_invalidate_arrange = () => TextBlock.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => TextBlock.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(TextBlock), "Wrapping")]
    public class when_text_wrapping_is_changed : a_Measured_and_Arranged_TextBlock
    {
        private Because of = () => TextBlock.Wrapping = TextWrapping.Wrap;

        private It should_invalidate_arrange = () => TextBlock.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => TextBlock.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(TextBlock), "Wrapping")]
    public class when_wrapping_is_not_required : a_TextBlock_With_Content
    {
        private Because of = () => RootElement.Object.Update();

        private It should_not_wrap = () => TextBlock.DesiredSize.Height.ShouldEqual(SentenceSize.Y);
    }

    [Subject(typeof(TextBlock), "Wrapping")]
    public class when_wrapping_is_required : a_TextBlock_With_Content
    {
        private const string NewLine = "\n";

        private const string WrappedSentence =
            Word + Space + Word + NewLine + Word + Space + Word + NewLine + Word + Space + Word + NewLine + Word;

        private static readonly Vector2 wrappedSentenceSize = new Vector2(85, 30);

        private Establish context =
            () => SpriteFont.Setup(font => font.MeasureString(WrappedSentence)).Returns(wrappedSentenceSize);

        private Because of = () =>
            {
                TextBlock.Wrapping = TextWrapping.Wrap;
                RootElement.Object.Update();
            };

        private It should_wrap = () => TextBlock.DesiredSize.Height.ShouldEqual(wrappedSentenceSize.Y);
    }

    [Subject(typeof(TextBlock), "Wrapping")]
    public class when_changing_text : a_TextBlock_With_Content
    {
    }
}