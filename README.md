# Blue Archive Big Watermelon（Unity 2D 合成玩法原型）

基于 Unity 2D 物理与标签规则的合成/得分玩法原型：物体按数值标签区分等级，发生碰撞时根据标签大小进行判定、加分与销毁；到达裁判线并停留一定时间则游戏结束。

> 引擎：Unity 2019.4.40f1c1  

## 玩法概述
碰撞判定：

- 当较高标签与较低标签碰撞时，销毁较低标签对象并加分（5 × 对方标签值）与播放对应音效。

游戏结束判定：
- 物体进入裁判线触发器并持续停留满 2 秒时，弹出 GameOver 面板并结束游戏。

随机生成：
- 通过全局水果列表按一定范围随机选择生成。

[<img src="https://s21.ax1x.com/2025/10/30/pVxqrNV.png" alt="pVxqrNV.png" style="zoom:33%;" />](https://imgchr.com/i/pVxqrNV)[<img src="https://s21.ax1x.com/2025/10/30/pVxqshT.md.png" alt="pVxqshT.md.png" style="zoom:33%;" />](https://imgchr.com/i/pVxqshT)