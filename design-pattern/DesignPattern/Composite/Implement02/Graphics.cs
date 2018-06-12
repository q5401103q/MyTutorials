using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement02
{
    /// <summary>
    /// 透明式的Composite模式
    /// 
    /// Line，Rectangle，Circle已经没有了子对象，
    /// 它是一个基本图像元素，因此Add()，Remove()的方法对于它来说没有任何意义，
    /// 而且把这种错误不会在编译的时候报错，把错误放在了运行期，
    /// 我们希望能够捕获到这类错误，并加以处理
    /// </summary>
    public abstract class Graphics
    {
        protected string _name;

        public Graphics(string name)
        {
            this._name = name;
        }

        public abstract void Draw();
        public abstract void Add(Graphics graphic);
        public abstract void Remove(Graphics graphic);
    }
}
