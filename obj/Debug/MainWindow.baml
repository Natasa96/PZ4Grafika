   M S B A M L   `   `   `  ����L  HPredmetniZadatak4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PredmetniZadatak4PredmetniZadatak4  5   	   "    PredmetniZadatak4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   W SHelixToolkit.Wpf, Version=2.6.1.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d(helixhttp://helix-toolkit.org/wpf  5   	   +localclr-namespace:PredmetniZadatak4  5   	     � Title$  
MainWindow��5	   	   $	��800��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowState$ 	Maximized=�6Z   .��5
      � .+�5   
   '� -   5         '�Name$ viewPort��5      }�.  '� Camera 5      =� 5      -   5        
CameraMain�� � Position$ 500 600 12001�5   8    � LookDirection$ 0 -7 -85�5   $   .x�5      g�  g� Content 5      t� 5      -   5        DirectionalLightMain�� t� 	Direction$ -1 -1 -15�5   E   5      g� 5      -   5        MapModel�� 5      h� 5      -   5        	GroupMain��.��5      t� $ 0,-10,05�6+   � 5      -   5        Back��	 � Material	 5      u� 5   "   
 u� Brush

 �����62    � Geometry 5!      k� 5"   "    k� 	Positions �    �/ �/ k� TriangleIndices �     5#   1   5%      � 5'      -   5        Top��	 5(      u� 5)   "   
 5*   &   �� 5+   *    �� ImageSource$ /Images/PZ4 - map.jpg��65    j� TileMode$
 Tile=�6Y   5-   #    5/      k� 50   "   % �    �/ �/ �/ �/ �      k� TextureCoordinates �   52   1   54      � 56      -   5        Left��	 57      u� 58   "   

 �����62    5:      k� 5;   "    �    �/ �/ �     5<   1   5>      � 5@      -	   5        
Bottom��	 5A      u� 5B   "   

 ����62    5D      k� 5E   "   % �    �/ �/ �/ �/ �     5F   1   5H      � 5J      -
   5        	Right��	 5K      u� 5L   "   

 ��� �62    5N      k� 5O   "   - �    �/ �/ �/ �/ �/ �/ �     5P   1   5R      � 5T      -   5        	Front��	 5U      u� 5V   "   

 ����62    5X      k� 5Y   "   - �    �/ �/ �/ �/ �/ �/ �     5Z   1   5\       j� 	Transform 5]      Y� 5^      .�5_   "   S� -   5        translacija�� S� OffsetY$ 0Q�5_   L    S� OffsetX$ 0Q�6X    S� OffsetZ$ 0Q�6d   �� 5`   "   -   5        
skaliranje�� �� ScaleX$ 1Q�5`   G    �� ScaleY$ 1Q�6R    �� ScaleZ$ 1Q�6]   �� 5a   "    �� Rotation 5b   &   �� 5c   *   -   5        rotacija�� �� Axis$ 0 1 05�5c   P    �� Angle$ 1Q�6]   5e   #   5f      5z      5|      5}      5~      5      