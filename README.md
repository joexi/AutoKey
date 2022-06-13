# AutoKey
魔兽挂机助手

# Provide
* 一个程序影响一个魔兽窗口，互不影响
* 防暂离
* 自动打怪
* 自动拾取
* 事件依赖，执行A再执行B

# 部分功能需要结合宏命令使用
* 自动拾取需要结合2步操作，将2个行为单独设置按键，然后依次点击即可
  * 选中上一个目标
  * 与目标交互


![image](https://user-images.githubusercontent.com/3711488/157415473-71564efb-3f1e-4151-9b0b-a7ae3f994c2c.png)

### 宠物拉怪宏
  功能：没有宠物时召唤宠物，有宠物时去攻击怪物，进战斗后回到角色身边
``` lua
/cast [nopet] 召唤XXXX
/petattack [nocombat]
/petfollow [combat]
```

### 寻找目标宏
  功能：找XXXX没找到就找YYYY
  
``` lua
/target XXXX;
/stopmacro [@target, exists, nodead]
/target YYYY;
```

### 释放技能宏
``` lua
/castsequence reset=30/combat/ XXXX,XXXX,XXXX
```
