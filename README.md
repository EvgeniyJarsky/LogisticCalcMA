разметка для WPF

<Window x:Class="WPF_UI.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WPF_UI"
        mc:Ignorable="d"
        Title="MainWindow" Height="460" Width="300">
    <Grid>
        <StackPanel>
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <StackPanel>
                    <Label Content="   "></Label>
                    <Label Content="Ставка с НДС"></Label>
                    <Label Content="Ставка без НДС"></Label>
                </StackPanel>
                
                <StackPanel>
                    <Label Content="Норм."></Label>
                    <Label Content="40000"></Label>
                    <Label Content="54000"></Label>
                </StackPanel>

                <StackPanel>
                    <Label Content="Макс."></Label>
                    <Label Content="40000"></Label>
                    <Label Content="54000"></Label>
                </StackPanel>

            </StackPanel>

            <Separator />

            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Label>Ставка с НДС</Label>
                <Label>SUMM1</Label>
                <Label>SUMM2</Label>
            </StackPanel>

            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Label>Ставка без НДС</Label>
                <Label>SUMM1</Label>
                <Label>SUMM2</Label>
            </StackPanel>

            <Button Content="Рассчитать ставку" Width="150"></Button>

            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <CheckBox IsThreeState="False" Height="20" IsChecked="False"></CheckBox>
                <Label Content="Округлять"></Label>
            </StackPanel>

            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <StackPanel>
                    <Label HorizontalAlignment="Center" Content="Ставка"></Label>
                    <TextBlock></TextBlock>
                    <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                        <Button Content="-1000" Width="75"></Button>
                        <Button Content="+1000" Width="75"></Button>
                    </StackPanel>
                </StackPanel>

                <StackPanel>
                    <Label HorizontalAlignment="Center" Content="Комиссия"></Label>
                    <TextBlock></TextBlock>
                    <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                        <Button Content="-1000" Width="75"></Button>
                        <Button Content="+1000" Width="75"></Button>
                    </StackPanel>
                </StackPanel>

            </StackPanel>

            <StackPanel>
                <Label HorizontalAlignment="Center" Content="Запас"></Label>
                <TextBlock></TextBlock>
                <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                    <Button Content="-1000" Width="75"></Button>
                    <Button Content="+1000" Width="75"></Button>
                </StackPanel>
            </StackPanel>

        </StackPanel>
    </Grid>
</Window>
