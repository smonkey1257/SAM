using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartAlamSystem.UControls
{
    public partial class CircleButton : Button
    {
        public CircleButton()
        {
            InitializeComponent();

            #region 设置控件样式标志
            SetStyle(ControlStyles.UserPaint, true);                // 控件由其自身而不是操作系统绘制
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);     // 忽略窗口消息，减少闪烁
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);    // 绘制到缓冲区，减少闪烁
            SetStyle(ControlStyles.ResizeRedraw, true);             // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);//支持透明背景
            #endregion
        }
    }
}

/**
 * InitializeComponent方法的主要作用：
 * - 创建控件对象并初始化其属性
 * - 设置控件的默认值和初始状态
 * - 建立控件间的父子关系
 * - InitializeComponent通常是在构造函数中由设计器生成的代码调用，此时控件尚未完成完整的初始化流程，窗口句柄也可能尚未创建。
 * 
 * 
 * ControlStyles.UserPaint
 * - 作用：控件将自行绘制，而不是通过操作系统绘制
 * - 区别：
 *   - 操作系统绘制（UserPaint = false）：由 Windows 系统原生 API（如 user32.dll）直接处理控件的绘制逻辑。系统根据控件的类型（如按钮、文本框）自动生成默认外观，开发者无法干预绘制细节。例如，标准按钮的边框、背景色、按下状态等均由系统定义
 *   - 自行绘制（UserPaint = true）​：控件通过重写 OnPaint 方法或处理 Paint 事件，使用 GDI+（System.Drawing）在代码中实现绘制逻辑。开发者需手动处理所有视觉元素，包括背景、边框、文本、状态变化（如悬停、点击）等
 *   
 *   
 * ControlStyles.AllPaintingInWmPaint
 * - 作用：控件将忽略 WM_ERASEBKGND 消息以减少闪烁。仅当 UserPaint 样式设置为 true 时生效
 * - 延申：
 *   - WM_ERASEBKGND 消息是什么消息，它有哪些，涉及到了什么？
 *   - 闪烁：控件闪烁的现象是怎么样的？
 */