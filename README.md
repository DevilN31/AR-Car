# AR Car

Preperation for build:
1) Remove ARCore from the project, ARDK has it's own AR API. 
2) Player Settings:
    - Other Settings
      - Remove Vulkan from Graphics API
      - Set minimum API to 25 and maximum to 33
      - Set Scripting Backend to IL2CPP
      - Set Target Architectures to both ARMv7 and ARM64
    - Publishing Settings
      - Toggle Custom Base Gradle Template
3) Gradle Template:
    - Set Classpath to 'com.android.tools.build:gradle:4.2.0'
4) Gradle:
    - Download Gradle version 6.9.2
    - In Unity -> Preferences -> Eternal Tools set Gradle to the vestion you just downloaded.

   
