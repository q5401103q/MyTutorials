using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Composite.Implement03
{
    /// <summary>
    /// 安全式的Composite模式
    /// 
    /// 它也使得叶子节点和树枝构件具有不一样的接口
    /// 这种方式和透明式的Composite各有优劣，
    /// 具体使用哪一个，需要根据问题的实际情况而定
    /// </summary>
    public abstract class Graphics
    {
        protected string _name;

        public Graphics(string name)
        {
            this._name = name;
        }

        public abstract void Draw();
    }
}
