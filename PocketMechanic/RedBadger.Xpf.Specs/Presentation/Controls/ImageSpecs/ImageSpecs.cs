//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.ImageSpecs
{
    using System.Windows;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Media;
    using RedBadger.Xpf.Presentation.Media.Imaging;

    using It = Machine.Specifications.It;

    public abstract class an_image
    {
        protected static Mock<IDrawingContext> DrawingContext;

        protected static Image Image;

        protected static Mock<RootElement> RootElement;

        private static Mock<IRenderer> renderer;

        private Establish context = () =>
            {
                renderer = new Mock<IRenderer>();
                DrawingContext = new Mock<IDrawingContext>();
                renderer.Setup(r => r.GetDrawingContext(Moq.It.IsAny<IElement>())).Returns(DrawingContext.Object);
                RootElement = new Mock<RootElement>(renderer.Object, new Rect(new Size(100, 100))) { CallBase = true };
                Image = new Image();
                RootElement.Object.Content = Image;
            };
    }

    public abstract class a_smaller_Image
    {
        protected static readonly Size AvailableSize = new Size(9, 20);

        protected static readonly Size ImageSize = new Size(3, 4);

        protected static Image Image;

        protected static Mock<ITexture2D> Texture;

        private Establish context = () =>
            {
                Texture = new Mock<ITexture2D>();
                Texture.Setup(d => d.Width).Returns((int)ImageSize.Width);
                Texture.Setup(d => d.Height).Returns((int)ImageSize.Height);
                Image = new Image { Source = new XnaImage(Texture.Object) };
            };
    }

    public abstract class a_larger_Image
    {
        protected static readonly Size AvailableSize = new Size(6, 10);

        protected static readonly Size ImageSize = new Size(8, 20);

        protected static Image Image;

        protected static Mock<ITexture2D> Texture;

        private Establish context = () =>
            {
                Texture = new Mock<ITexture2D>();
                Texture.Setup(d => d.Width).Returns((int)ImageSize.Width);
                Texture.Setup(d => d.Height).Returns((int)ImageSize.Height);
                Image = new Image { Source = new XnaImage(Texture.Object) };
            };
    }

    public abstract class a_measured_and_arranged_Image : a_smaller_Image
    {
        private Establish context = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_smaller_image_is_set_to_not_stretch : a_smaller_Image
    {
        private Establish context = () => Image.Stretch = Stretch.None;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_that_of_the_image_source =
            () => Image.DesiredSize.ShouldEqual(ImageSize);

        private It should_have_a_render_size_equal_to_that_of_the_image_source =
            () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_smaller_image_is_set_to_stretch_value_of_Uniform : a_smaller_Image
    {
        private static readonly Size ExpectedSize = new Size(
            AvailableSize.Width, ImageSize.Height * (AvailableSize.Width / ImageSize.Width));

        private Establish context = () => Image.Stretch = Stretch.Uniform;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_the_correct_desired_size = () => Image.DesiredSize.ShouldEqual(ExpectedSize);

        private It should_have_the_correct_render_size = () => Image.RenderSize.ShouldEqual(ExpectedSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_smaller_image_is_set_to_stretch_value_of_Uniform_but_not_allowed_to_expand : a_smaller_Image
    {
        private Establish context = () =>
            {
                Image.Stretch = Stretch.Uniform;
                Image.StretchDirection = StretchDirection.DownOnly;
            };

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_image_size = () => Image.DesiredSize.ShouldEqual(ImageSize);

        private It should_have_a_render_size_equal_to_the_image_size = () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_smaller_image_is_set_to_a_stretch_value_of_Fill : a_smaller_Image
    {
        private Establish context = () => Image.Stretch = Stretch.Fill;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_a_render_size_equal_to_the_available_size =
            () => Image.RenderSize.ShouldEqual(AvailableSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_smaller_image_is_set_to_a_stretch_value_of_Fill_but_not_allowed_to_expand : a_smaller_Image
    {
        private Establish context = () =>
            {
                Image.Stretch = Stretch.Fill;
                Image.StretchDirection = StretchDirection.DownOnly;
            };

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_image_size = () => Image.DesiredSize.ShouldEqual(ImageSize);

        private It should_have_a_render_size_equal_to_the_image_size = () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_smaller_image_is_set_to_a_stretch_value_of_UniformToFill : a_smaller_Image
    {
        private static readonly Size ExpectedRenderSize =
            new Size(ImageSize.Width * (AvailableSize.Height / ImageSize.Height), AvailableSize.Height);

        private Establish context = () => Image.Stretch = Stretch.UniformToFill;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_the_correct_render_size = () => Image.RenderSize.ShouldEqual(ExpectedRenderSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_smaller_image_is_set_to_a_stretch_value_of_UniformToFill_but_not_allowed_to_expand :
        a_smaller_Image
    {
        private Establish context = () =>
            {
                Image.Stretch = Stretch.UniformToFill;
                Image.StretchDirection = StretchDirection.DownOnly;
            };

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_image_size = () => Image.DesiredSize.ShouldEqual(ImageSize);

        private It should_have_a_render_size_equal_to_the_image_size = () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_larger_image_is_set_to_not_stretch : a_larger_Image
    {
        private Establish context = () => Image.Stretch = Stretch.None;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_a_render_size_equal_to_that_of_the_image_source =
            () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_larger_image_is_set_to_stretch_value_of_Uniform : a_larger_Image
    {
        private static readonly Size ExpectedSize = new Size(
            ImageSize.Width / (ImageSize.Height / AvailableSize.Height), AvailableSize.Height);

        private Establish context = () => Image.Stretch = Stretch.Uniform;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_the_correct_desired_size = () => Image.DesiredSize.ShouldEqual(ExpectedSize);

        private It should_have_the_correct_render_size = () => Image.RenderSize.ShouldEqual(ExpectedSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_larger_image_is_set_to_stretch_value_of_Uniform_but_not_allowed_to_shrink : a_larger_Image
    {
        private Establish context = () =>
            {
                Image.Stretch = Stretch.Uniform;
                Image.StretchDirection = StretchDirection.UpOnly;
            };

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_a_render_size_equal_to_the_image_size = () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_larger_image_is_set_to_a_stretch_value_of_Fill : a_larger_Image
    {
        private Establish context = () => Image.Stretch = Stretch.Fill;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_a_render_size_equal_to_the_available_size =
            () => Image.RenderSize.ShouldEqual(AvailableSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_larger_image_is_set_to_a_stretch_value_of_Fill_but_not_allowed_to_shrink : a_larger_Image
    {
        private Establish context = () =>
            {
                Image.Stretch = Stretch.Fill;
                Image.StretchDirection = StretchDirection.UpOnly;
            };

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_a_render_size_equal_to_the_image_size = () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_larger_image_is_set_to_a_stretch_value_of_UniformToFill : a_larger_Image
    {
        private static readonly Size ExpectedRenderSize = new Size(
            AvailableSize.Width, ImageSize.Height * (AvailableSize.Width / ImageSize.Width));

        private Establish context = () => Image.Stretch = Stretch.UniformToFill;

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_the_correct_render_size = () => Image.RenderSize.ShouldEqual(ExpectedRenderSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_a_larger_image_is_set_to_a_stretch_value_of_UniformToFill_but_not_allowed_to_shrink :
        a_larger_Image
    {
        private Establish context = () =>
            {
                Image.Stretch = Stretch.UniformToFill;
                Image.StretchDirection = StretchDirection.UpOnly;
            };

        private Because of = () =>
            {
                Image.Measure(AvailableSize);
                Image.Arrange(new Rect(AvailableSize));
            };

        private It should_have_a_desired_size_equal_to_the_available_size =
            () => Image.DesiredSize.ShouldEqual(AvailableSize);

        private It should_have_a_render_size_equal_to_the_image_size = () => Image.RenderSize.ShouldEqual(ImageSize);
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_stretch_is_changed : a_measured_and_arranged_Image
    {
        private Because of = () => Image.Stretch = Stretch.UniformToFill;

        private It should_invalidate_arrange = () => Image.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => Image.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_stretch_direction_is_changed : a_measured_and_arranged_Image
    {
        private Because of = () => Image.StretchDirection = StretchDirection.DownOnly;

        private It should_invalidate_arrange = () => Image.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => Image.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_image_source_is_changed : a_measured_and_arranged_Image
    {
        private Because of = () => Image.Source = new XnaImage(new Mock<ITexture2D>().Object);

        private It should_invalidate_arrange = () => Image.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => Image.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(Image), "Stretch")]
    public class when_an_image_source_is_specified : an_image
    {
        private static XnaImage imageSource;

        private Because of = () =>
            {
                imageSource = new XnaImage(new Mock<ITexture2D>().Object);
                Image.Source = imageSource;
                RootElement.Object.Update();
                RootElement.Object.Draw();
            };

        private It should_render_the_image =
            () => DrawingContext.Verify(drawingContext => drawingContext.DrawImage(imageSource, Moq.It.IsAny<Rect>()));

        private It should_render_the_image_with_the_correct_size =
            () =>
            DrawingContext.Verify(
                drawingContext =>
                drawingContext.DrawImage(
                    Moq.It.IsAny<ImageSource>(), 
                    Moq.It.Is<Rect>(rect => rect.X == 0 && rect.Y == 0 && rect.Size == Image.RenderSize)));
    }
}