param($server, $database, $username, $password, $sourcePath)
write-host "server: $server"
write-host "database: $database"
write-host "username: $username"
write-host "password: $password"
write-host "sourcePath: $sourcePath"
write-host ""

write-host "reading 'migrations.json'"
$migrationsFile = "$sourcePath\Database\Migrations\NextRelease\migrations.json"
$json = (Get-Content $migrationsFile -Raw) | ConvertFrom-Json
foreach($script in $json)
{
    $index = $script.IndexOf("Database\\", [System.StringComparison]::OrdinalIgnoreCase)
    if ($index -eq 0)
    {
        $file = "$sourcePath\$script"
    }
    else
    {
        $file = "$sourcePath\Database\Migrations\NextRelease\$script"
    }

    write-host "executing: $file"

    INVOKE-Sqlcmd -Username $username@$server -Password $password -ServerInstance $server -Database $database -ConnectionTimeout 60 -InputFile $file

    write-host ""
}
