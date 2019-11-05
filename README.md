# AutoKey
魔兽挂机助手

# Provide
* 防暂离
* 原地自动打怪
* 原地拾取


# TODO
* 严格控制命令时序
* 命令组
* 同时映射到多个窗口（五火球）
* 分别控制多个窗口（目前只能靠多开）
* 识别当前血量
* 战场挂机

# 结合宏命令食用更佳

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
/stopmacro [@target, exsits, nodead]
/target YYYY;
```

### 释放技能宏
``` lua
/castsequence reset=30/combat/ XXXX,XXXX,XXXX
```
