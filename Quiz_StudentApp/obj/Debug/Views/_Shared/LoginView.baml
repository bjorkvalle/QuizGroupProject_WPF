   M S B A M L   `   `   `  ����J  FQuiz_StudentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Quiz_StudentApp.View._SharedQuiz_StudentApp.View._Shared  5      ,    &Quiz_StudentApp.View._Shared.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Quiz_StudentApp.View._Shared     5        N� Title$  	LoginView��5	       � 	Resources 5
         LoginAnimate �� TargetProperty �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%w  &	        �� 5   
   .��5      r� $ (FrameworkElement.Margin)�6/   $ 
stackPanel��6e   .	�5        $ 0��6*   $ 0,30,0,0q�66     5      $ 0:0:1��6*   $ 0q�6:   5      U� 5      $ (UIElement.Opacity)�6,   $ 
stackPanel��6\   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:1��6'   $ 1Q�67   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 FrameworkElement.Loaded��6   .[�5      �� #��[  6   5      .��5      � ��5   
   �� 5      
 �� ImageSource$5
 //Quiz_StudentApp;component/Data/Images/img5.jpg��6    j� Stretch$ UniformToFill=�6W   .+�5"   
   �� -   5         ��Name$ 
stackPanel��5"      $��Center=�6)   $��Center=�6D   .+�5#      �� -   5         ��Name$ image��5#      $��90��6#   $=��7/Quiz_StudentApp;component/Data/Images/Newton_White.png��61   $��Center=�6r   $��43.011��6�   $��207.312��6�   $��0,0,0,20q�6�   �� 5$      $��Username��6   $��28,0,0,0q�6'   
�������69   �� 5%      -   5         ��Name$ UsernameBox��5%   <   $��30��6   $	��150��6"   $��20(�6.   6<   �� 5&      $��Password��6   $��28,0,0,0q�6'   
�������69   G� 5'      -   5         G�Name$ PasswordBox��5'   @   $��30��6   $	��150��6&   $��20(�62   6@   �� 5(      -   5         ��Name$ errormessageBox��5(   )   $��0,5,0,0q�6   $$��Incorrect username or password��6B   
������� �� TextAlignment$ Center=�6{   $��Italic$�6�   $��10.667(�6�   $y�	Collapsed=�6�   �� 5)      -   5        $��148.374��5)      $��0,10,0,0q�6%   $��Login��67   
�������$
��Bold"�6�   ��6t   Z� ��6�   Z� ��6�   ��  �� Mode$ OneWay=�  MyButtonStyle �� Source# [ 5*      5+      5,      