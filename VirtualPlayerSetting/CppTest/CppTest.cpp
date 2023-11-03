

#include <Windows.h>
#include <iostream>


typedef int ( *FUNC1 )( int a, int b );

int main()
{
  auto hModule = LoadLibrary( L"SampleDLL.dll" );
//  auto hModule = LoadLibrary( L"C:\\WorkSpace\\VirtualPlayerSetting\\SampleDLL\\bin\Debug\\net6.0\\SampleDLL.dll" );


  if( NULL == hModule ) return 1;


  FUNC1 sum = (FUNC1)GetProcAddress( hModule, "Sum" );

  int val = sum( 1, 2 );

  std::cout << val << std::endl;

  return 0;
}

