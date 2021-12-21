rmdir /s /q "./testresults"
dotnet test ./"Excersize 5 Lexicon Tests" --collect:"XPlat Code Coverage" --results-directory:"./testresults/unittests"
dotnet %UserProfile%\.nuget\packages\reportgenerator\5.0.0\tools\net6.0\ReportGenerator.dll -reports:"./testresults/**/coverage.cobertura.xml" -targetdir:coveragereport -reporttypes:Html