   M S B A M L   `   `   `  ����O  KILSpy, Version=2.1.0.1603, Culture=neutral, PublicKeyToken=d4bfe873e7598c49G(clr-namespace:ICSharpCode.ILSpy.ControlsICSharpCode.ILSpy.Controls  5   �   &     ICSharpCode.ILSpy.OpenListDialog   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6-   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6o   =controls(clr-namespace:ICSharpCode.ILSpy.Controls     6�     � Title$  打开列表��5         DialogWindow#���   5       � WindowStartupLocation$ CenterOwner=�5       � 
ResizeMode$ CanResizeWithGrip=�5      $	��380��5      $	��250��5      $	��350��5	      $	��380��5
       +� FocusedElement 5      ��  �� ElementName$ listView��.��5      � $
��12,8q�6    � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $��1* �6   �� 5      $
��Auto �6   .+�5      �� .+�5      �� $��  ��6   5      �� 5      -   5        $��listView��5      $��1��6   $
��0, 8q�6*   7   1ICSharpCode.ILSpy.Controls.SortableGridViewColumn   SortMode$ 	Automatic=�68    �� SelectionMode$ Single=�5        �� View 5      �� 5      .P�5        -   5        
nameColumn��$��名称��5   ;   	 �� DisplayMemberBinding	 6G   �� *.+5      5      ]� 5      $��2��6   .+�5      �� $��Right=�6   
 �� Orientation$
 
Horizontal=�6(   $��Right=�6A   .+�5      �� -   5        $��okButton��5   =    �� 	IsDefault . $	��2,0q�6   {�.  .��6d   打开6h   �� 5        �� IsCancel . $	��2,0q�6   .��6*   取消6.   5!      �� 5#      $
��Left=�6   $
 
Horizontal=�6'   $
��Left=�6@   .+�5$      �� -   5        $	��2,0q�5$      .��65   创建69   �� 5%      -   5        $��removeButton��5%   ,   $	��2,0q�6   {�.  .��6[   移除6_   5&      5'      5(      5)      