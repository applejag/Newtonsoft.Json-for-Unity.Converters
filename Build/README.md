# Continuous Integration for Newtonsoft.Json-for-Unity.Converters

This is how to make it build inside CircleCI. The licenses are needed to be
added via environment variables inside the project settings within CircleCI.

## Obtain Unity license .ulf files

Repeat the following steps for the following versions:

- 2018.4.14f1
- 2019.2.11f1
- 2020.1.0b6-linux-il2cpp

1. Run `Build/local_docker_run.ps1` in PowerShell with `-UnityVersion` parameter
   being set to Unity version, ex:

   ```powershell
   # Assuming working directory is at repo root
   &'.\Build\local_docker_run.ps1' -UnityVersion '2019.2.11f1'
   ```

   If running Linux or MacOS, you can install [PowerShell Core](https://github.com/PowerShell/PowerShell)
   to run PowerShell scripts, and then invoke the script like so:

   ```bash
   # Assuming working directory is at repo root
   pwsh ./Build/local_docker_run.ps1 -UnityVersion '2019.2.11f1'
   ```

   If using Git Bash for Windows or WSL, you could also run the script like so:
   ```bash
   # Assuming working directory is at repo root
   powershell.exe ./Build/local_docker_run.ps1 -UnityVersion '2019.2.11f1'
   ```

2. Enter personal username+password

3. Wait for the log to spit out XML

4. Copy that XML

5. Paste that XML into a new file with the `.alf` extension,
   ex: `Unity_v2019.2.11f1.alf`

6. Go to <https://license.unity3d.com/manual>

7. Login with the same username+password as mentioned in step 2.

8. Upload the `.alf` file mentioned in step 5.

9. Follow the instructions, for example select "Personal license"

10. Download the new license

11. Place it into the `Build` folder inside this repo
    *(don't worry, it's ignored in .gitignore)* and rename it to follow the
    format `Unity_v${UnityVersion}.ulf`, ex: `Unity_v2019.2.11f1.ulf`

## Add licenses to CircleCI environment variables

1. Get the base-64 formatted content of the license files `.ulf`. Tip to save
    these as `*.b64` so you then can copy paste the content of the files into
    CircleCI.
   
    For example, in bash:
    ```bash
    # Assuming working directory is at repo root
    for file in Build/*.ulf; do base64 -w0 $file > $file.b64; done
    ```

    in PowerShell:
    ```powershell
   # Assuming working directory is at repo root
    Get-ChildItem Build/*.ulf | % {
        $bytes = [System.Text.Encoding]::UTF8.GetBytes((Get-Content $_))
        [System.Convert]::ToBase64String($bytes) > "Build/$($_.Name).b64"
    }
    ```

2. Copy the content of these `.ulf.b64` files and add them as variables inside
    the CircleCI settings.
    
    > For jilleJr/Newtonsoft.Json-for-Unity.Converters, that page is found at
    > <https://app.circleci.com/settings/project/github/jilleJr/Newtonsoft.Json-for-Unity.Converters/environment-variables>

    Here's a table of the desired contents:

    | File | Variable name |
    | --- | --- |
    | Unity_v2018.4.14f1.ulf.b64 | UNITY_2018_4_14f1_LICENSE_CONTENT_B64
    | Unity_v2019.2.11f1.ulf.b64 | UNITY_2019_2_11f1_LICENSE_CONTENT_B64
    | Unity_v2020.1.0b6-linux-il2cpp.ulf.b64 | UNITY_2020_1_0b6_LICENSE_CONTENT_B64

3. All done!

If you're curious where the variable names are references; search for them in
the `.circleci/config.yml` file.
