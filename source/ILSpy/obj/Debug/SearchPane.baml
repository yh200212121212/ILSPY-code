   M S B A M L   `   `   `  ����O  KILSpy, Version=2.1.0.1603, Culture=neutral, PublicKeyToken=d4bfe873e7598c49G(clr-namespace:ICSharpCode.ILSpy.ControlsICSharpCode.ILSpy.Controls  5   :   "    ICSharpCode.ILSpy.SearchPane   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    65   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =controls(clr-namespace:ICSharpCode.ILSpy.Controls     6:   @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          >�Name$
  self��5   J   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5      �� $��0,0,0,1q�6   #��� ��6%   #��� ��6r   ._�5      � $��23��6
    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      *   $ICSharpCode.ILSpy.Controls.SearchBox  -   5          Name$ 	searchBox��5      *   $ICSharpCode.ILSpy.Controls.SearchBox   PreviewKeyDown$ SearchBox_PreviewKeyDown��5      $	��Top=�5   ,   $��0��6A   $��0��6Q   $��1q�6^    � ToolTip$ Search��5   5      UpdateDelay$ 0:0:0.1h�6F      WatermarkColor
 �����   WatermarkText$ Search��5      ��5      �� *
SearchTerm+	 �� ElementName$
	 self��5      �� 5      $��1��6   $��0��6!   
 �� Orientation$
 
Horizontal=�6.   .+�5      �� $
��0,-1q�6   .��6   搜索目标:6"   �� 5      -   5        $��searchModeComboBox��5      $	��100��6   $��1q�66   ��5      �� 5   	   .R�5   
   �� $
 
Horizontal=�6   .+�5      �� $��16��6   $��0,0,4,0q�6   $��16��6.   ��69   �� *Image+�� 5      ��6   �� *Name+5      5   
   5!      5"      5#      5$      �� 5%      -   5        $��listBox��5&   1   $��1��5%      $��0,0,0,0q�6   $��Stretch=�63    �� SelectionMode$ Single=�5&   @   ��5'      �� 5(      .R�5)      �  5*      �� 5+   	   $��20 �6   �� 5,   	   $
��Auto �6   �� 5-   	   $��* �6   .+�5/      �� $��16��6   $��16��6   $
��Left=�6%   ��6@   �� *Image+�� 50      $��1��6   ��6"   �� *Name+�� 51      $��2��6   $��Right=�6#   $
 
Horizontal=�6?   $��0,0,2,0q�6X   .+�52   	   �� $��16��6   $��4,0,4,0q�6   $��16��6,   ��67   �� *LocationImage+�� 53   	   $��CharacterEllipsis=�6-   ��6   �� *
Location+6-   54   	   55      56      58      59      5:      