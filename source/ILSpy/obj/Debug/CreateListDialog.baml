   M S B A M L   `   `   `  ����O  KILSpy, Version=2.1.0.1603, Culture=neutral, PublicKeyToken=d4bfe873e7598c49G(clr-namespace:ICSharpCode.ILSpy.ControlsICSharpCode.ILSpy.Controls  5   �   (    "ICSharpCode.ILSpy.CreateListDialog   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6/   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6q   =controls(clr-namespace:ICSharpCode.ILSpy.Controls     6�     � Title$  新建列表��5         DialogWindow#���   5       � WindowStartupLocation$ CenterOwner=�5       � 
ResizeMode$ NoResize=�5      $	��300��5      $	��150��5       +� FocusedElement 5	      ��  �� ElementName$ ListName��.��5
      � $
��12,8q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� .+�5      �� .��6   输入列表名称:6   �� 5      -   5        $��ListName��5   #   $	��8,8q�6   6W   5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $	��8,0q�6W   .+�5      �� -   5        $��okButton��5   E    �� 	IsDefault . $	��2,0q�6&   {�.  .��6l   创建6p   �� 5       �� IsCancel . $	��2,0q�6%   .��62   取消66   5      5      5      