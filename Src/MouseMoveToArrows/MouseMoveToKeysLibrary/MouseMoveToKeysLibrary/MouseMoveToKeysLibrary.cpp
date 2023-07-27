// MouseMoveToKeysLibrary.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include <windows.h>
INPUT down[1], up[1], downa[1], upa[1], MiceW3[1], Micek[1], Micel[1], Micelf[1], Micerc[1], Micercf[1], Micemc[1], Micemcf[1], Micewd[1], Micewu[1];
bool downb, upb, downab, upab, MiceW3b, Micekb, Micelb, Micelfb, Micercb, Micercfb, Micemcb, Micemcfb, Micewdb, Micewub;
extern "C"
{
__declspec(dllexport) void SimulateKeyDown(UINT keyCode, UINT bScan)
{
if (!downb)
{
::ZeroMemory(down, sizeof(down));		
down[0].type = 1;
down[0].ki.dwFlags = 0;    
downb = true;
}
down[0].ki.wVk = keyCode;
down[0].ki.wScan = bScan;           
SendInput(1, down, sizeof(INPUT));
}
__declspec(dllexport) void SimulateKeyUp(UINT keyCode, UINT bScan)
{
if (!upb)
{
::ZeroMemory(up, sizeof(up));		
up[0].type = 1;	
up[0].ki.dwFlags = 0x0002; 
upb = true;
}
up[0].ki.wVk = keyCode;
up[0].ki.wScan = bScan;              
SendInput(1, up, sizeof(INPUT));
}
__declspec(dllexport) void SimulateKeyDownArrows(UINT keyCode, UINT bScan)
{
if (!downab)
{
::ZeroMemory(downa, sizeof(downa));		
downa[0].type = 1;
downab = true;
}
downa[0].ki.wVk = keyCode;
downa[0].ki.wScan = bScan;
downa[0].ki.dwFlags = 0x0001 | 0x0008;                   
SendInput(1, downa, sizeof(INPUT));
downa[0].ki.dwFlags = 0;               
SendInput(1, downa, sizeof(INPUT));
}
__declspec(dllexport) void SimulateKeyUpArrows(UINT keyCode, UINT bScan)
{
if (!upab)
{
::ZeroMemory(upa, sizeof(upa));		
upa[0].type = 1;	
upab = true;
}
upa[0].ki.wVk = keyCode;
upa[0].ki.wScan = bScan;
upa[0].ki.dwFlags = 0x0002 | 0x0001 | 0x0008;                 
SendInput(1, upa, sizeof(INPUT));
upa[0].ki.dwFlags = 0x0002;               
SendInput(1, upa, sizeof(INPUT));
}
__declspec(dllexport) void MouseMW3(int x, int y)
{
if (!MiceW3b)
{
::ZeroMemory(MiceW3, sizeof(MiceW3));		
MiceW3[0].type = 0;	
MiceW3[0].mi.dwFlags = 0x8001;
MiceW3b = true;
}
MiceW3[0].mi.dx = x;
MiceW3[0].mi.dy = y;
SendInput(1, MiceW3, sizeof(INPUT));
}
__declspec(dllexport) void MouseBrink(int x, int y)
{
if (!Micekb)
{
::ZeroMemory(Micek, sizeof(Micek));		
Micek[0].type = 0;	
Micek[0].mi.dwFlags = 0x0001;
Micekb = true;
}
Micek[0].mi.dx = x;
Micek[0].mi.dy = y;
SendInput(1, Micek, sizeof(INPUT));
}
__declspec(dllexport) void LeftClick()
{
if (!Micelb)
{
::ZeroMemory(Micel, sizeof(Micel));		
Micel[0].type = 0;	
Micel[0].mi.dwFlags = 0x0002;
Micelb = true;
}
SendInput(1, Micel, sizeof(INPUT));
}
__declspec(dllexport) void LeftClickF()
{
if (!Micelfb)
{
::ZeroMemory(Micelf, sizeof(Micelf));		
Micelf[0].type = 0;	
Micelf[0].mi.dwFlags = 0x0004;
Micelfb = true;
}
SendInput(1, Micelf, sizeof(INPUT));
}
__declspec(dllexport) void RightClick()
{
if (!Micercb)
{
::ZeroMemory(Micerc, sizeof(Micerc));		
Micerc[0].type = 0;	
Micerc[0].mi.dwFlags = 0x0008;
Micercb = true;
}
SendInput(1, Micerc, sizeof(INPUT));
}
__declspec(dllexport) void RightClickF()
{
if (!Micercfb)
{
::ZeroMemory(Micercf, sizeof(Micercf));		
Micercf[0].type = 0;	
Micercf[0].mi.dwFlags = 0x0010;
Micercfb = true;
}
SendInput(1, Micercf, sizeof(INPUT));
}
__declspec(dllexport) void MiddleClick()
{
if (!Micemcb)
{
::ZeroMemory(Micemc, sizeof(Micemc));		
Micemc[0].type = 0;	
Micemc[0].mi.dwFlags = 0x0020;
Micemcb = true;
}
SendInput(1, Micemc, sizeof(INPUT));
}
__declspec(dllexport) void MiddleClickF()
{
if (!Micemcfb)
{
::ZeroMemory(Micemcf, sizeof(Micemcf));		
Micemcf[0].type = 0;	
Micemcf[0].mi.dwFlags = 0x0040;
Micemcfb = true;
}
SendInput(1, Micemcf, sizeof(INPUT));
}
__declspec(dllexport) void WheelDownF()
{
if (!Micewdb)
{
::ZeroMemory(Micewd, sizeof(Micewd));		
Micewd[0].type = 0;		
Micewd[0].mi.mouseData = -120;	
Micewd[0].mi.dwFlags = 0x0800;
Micewdb = true;
}
SendInput(1, Micewd, sizeof(INPUT));
}
__declspec(dllexport) void WheelUpF()
{
if (!Micewub)
{
::ZeroMemory(Micewu, sizeof(Micewu));		
Micewu[0].type = 0;	
Micewu[0].mi.mouseData = 120;	
Micewu[0].mi.dwFlags = 0x0800;
Micewub = true;
}
SendInput(1, Micewu, sizeof(INPUT));
}
__declspec(dllexport) void setcursorpos(int x, int y)
{
SetCursorPos(x, y);
}
__declspec(dllexport) void getasynckeystate(int vkey)
{
GetAsyncKeyState((int)vkey);
}
__declspec(dllexport) void readfile(HANDLE hFile, LPVOID aBuffer[], DWORD cbToRead, LPDWORD cbThatWereRead)
{
ReadFile(hFile, aBuffer, cbToRead, cbThatWereRead, 0);
}
__declspec(dllexport) float Abs(float number)
{
return (static_cast<float>(number > 0 ? number : -number));
}
__declspec(dllexport) float Sign(float number)
{
return (static_cast<float>(number < 0 ? -1 : 1));
}
__declspec(dllexport) float Cos(float number)
{
return (static_cast<float>(-number / 90 + 1));
}
__declspec(dllexport) float Sin(float number)
{
return (static_cast<float>(number / 90));
}
}
