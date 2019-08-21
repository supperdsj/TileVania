* 使用 Tilemap 自动编辑地形
* 使用 Ruletiles 自动关联生成地形贴图
* 使用 Tilemap Collider + Composite Collider 为 Tilemap 生成 Collider    
* 使用 UnityStandardAssets.CrossPlatformInput 监听输入
* 对于高速物体将rigidbody的collision detection 设置为 Continuous
* 利用 myCollider2d.IsTouchingLayers(LayerMask.GetMask("Ground") 获取当前 collider是否与特定layer接触
* sprite editor 中可编辑物理轮廓
* 可为 Collider 添加 Physic Material 设置摩擦力和弹力
* 使用 Cinemachine 跟随对象/限制显示区域
* 使用 Cinemachine 可关联对象使用 State Drive Camera 切换不同 Camera
* Cinemachine 内设置 Noise 可以实现震动效果
