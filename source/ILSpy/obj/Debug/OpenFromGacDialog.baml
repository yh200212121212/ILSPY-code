   M S B A M L   `   `   `  ����O  KILSpy, Version=2.1.0.1603, Culture=neutral, PublicKeyToken=d4bfe873e7598c49G(clr-namespace:ICSharpCode.ILSpy.ControlsICSharpCode.ILSpy.Controls  5   �   )    #ICSharpCode.ILSpy.OpenFromGacDialog   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    60   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6r   =controls(clr-namespace:ICSharpCode.ILSpy.Controls     6�     � Title$  从GAC中打开��5         DialogWindow#���   5       � WindowStartupLocation$ CenterOwner=�5       � 
ResizeMode$ CanResizeWithGrip=�5      $	��200��5      $	��150��5	      $	��350��5
      $	��750��5       +� FocusedElement 5      ��  �� ElementName$ filterTextBox��.��5      � $
��12,8q�5       � RowDefinitions 5      �� 5      $
��Auto �5      �� 5      $��1* �5      �� 5      $
��Auto �5      .+�5      ]� .+�5      �� $
��Left=�6    �� Target 6!   �� $ filterTextBox��.��6N   搜索(_S):6W   �� 5      -   5        $��filterTextBox��5      6"   5      �� 5      -   5        $��listView��5      $��1��6   $
��0, 8q�6*   7   1ICSharpCode.ILSpy.Controls.SortableGridViewColumn   SortMode$ 	Automatic=�68    �� View 5      �� 5      .P�5        -   5        
nameColumn��	 �� Width$		 300��5   ;   $��引用名称��6G   
 �� DisplayMemberBinding
 6U   �� *	ShortName+  5      $	 75��6'   $��版本��62   
 6>   �� *	Version+  5       $	 65��6'   $��区域��62   
 6>   �� *	Culture+  5!      $		 115��6'   $��公钥标记��63   
 6A   �� *PublicKeyToken+  5"      $
	 1000��6'   $��位置��64   
 6@   �� *
FileName+5#      5%      �� 5&      $��2��6    �� Orientation$ 
Horizontal=�6   $��Right=�65   .+�5'      �� -   5        $��okButton��5'   <    �� 	IsDefault . $	��2,0q�6   {�.  .��6c   打开6g   �� 5(       �� IsCancel . $	��2,0q�6   .��6)   取消6-   5)      � 5*      -   5        $��gacReadingProgressBar��5*   G   $��1��6   $��10��6   $��Stretch=�6)   $��Bottom=�6d   $y�Hidden=�6   5+      5,      