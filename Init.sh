rm -rf DynamicAssemblyLoader/plugins

cd DynamicAssemblyLoader

mkdir plugins

cd plugins

mkdir Plugin.Bla1
mkdir Plugin.Bla2

cd ../..

cd plugins/Plugin.Bla1 

dotnet build

cp -R ./bin/Debug/netstandard2.0/* ../../DynamicAssemblyLoader/plugins/Plugin.Bla1/

cd ..

cd Plugin.Bla2 

dotnet build --force

cp -R ./bin/Debug/netstandard2.0/* ../../DynamicAssemblyLoader/plugins/Plugin.Bla2/
