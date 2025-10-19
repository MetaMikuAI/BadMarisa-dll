# BadMarisa-dll
A mod for Marisa!ReturnTheBook Demo (Only releases)

## Mod 功能

量化统计游戏数据并实时显示

<img width="527" height="383" alt="@GG5WFT%MPXWF2S36D4NNGP" src="https://github.com/user-attachments/assets/bff4896f-4e3d-43b3-b595-872ae104c621" />

<img width="501" height="873" alt="image" src="https://github.com/user-attachments/assets/a77feedf-3aa7-4b29-b3a6-4c75810c1330" />


请注意，毫秒计时器仅供参考，存在难以消除的系统性误差

## 使用教程

以 windows 为例

1. 下载 [BepInEx](https://github.com/BepInEx/BepInEx/releases)
2. 解压到游戏根目录如下

```
Marisa!ReturnTheBook! Demo
│  .doorstop_version
│  changelog.txt
│  doorstop_config.ini
│  MarisaReturnTheBook.exe
│  UnityCrashHandler64.exe
│  UnityPlayer.dll
│  winhttp.dll
├─BepInEx
├─MarisaReturnTheBook_BurstDebugInformation_DoNotShip
├─MarisaReturnTheBook_Data
└─MonoBleedingEdge
```

运行一次游戏，成功显示控制台即可

3. 将 mod (dll 文件) 放到 `./BepInEx/plugins/` 下重启游戏即可

## 版本

- `v0.3`：实现 基础的量化统计显示，包括 `MarisaHP`, 地上的书本数, 各玩偶数, **伪**毫秒计时器等，按 `S` 键切换显示
- `v0.4`：在对应人物旁边直接显示玩偶统计数，按 `D` 键切换显示。其中勇者琪露诺以 `星号*` 显示
- `v0.5`：增加伤害榜和回收榜的量化(对接阿求)，`R` 键切换显示榜单，`S` 键切换显示旧统计信息

默认为最新版，如果需要下载旧版本，请自行从 `commit` 历史中 `git checkout`

## 关于开源

涉及部分敏感代码，可能在之后主动开源

> <s>*为赶工做的，代码很乱，不要 `disassemble` 我口牙（有时间会优化的）*</s>

## 特别鸣谢

感谢 Narrow & 月咏 两位创作者为我们带来如此精致、有趣、又充满灵气的《Marisa! Return The Book!》。

无论是细腻的像素演出、灵动的操作手感，还是那份“魔理沙式”的幽默与可爱，都让人感受到满满的爱与巧思。

快来关注他们↓

- [Bilibili](https://space.bilibili.com/3546379490167245)
- [Narrow--](https://space.bilibili.com/414064)
- [月咏C](https://space.bilibili.com/396383605)
- [Steam](https://store.steampowered.com/app/3737620/)
