# CircleCI variables setup

This is how to make it build inside CircleCI. The licenses are needed to be
added via environment variables inside the project settings within CircleCI.

## Setup Unity licenses

### Obtain Unity license .ulf files

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

### Add licenses to CircleCI environment variables

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
    
    >For jilleJr/Newtonsoft.Json-for-Unity.Converters, that page is found at
    ><https://app.circleci.com/settings/project/github/jilleJr/Newtonsoft.Json-for-Unity.Converters/environment-variables>

    Here's a table of the desired variables:

    | File                                   | Variable name                         |
    | -------------------------------------- | ------------------------------------- |
    | Unity_v2018.4.14f1.ulf.b64             | UNITY_2018_4_14f1_LICENSE_CONTENT_B64 |
    | Unity_v2019.2.11f1.ulf.b64             | UNITY_2019_2_11f1_LICENSE_CONTENT_B64 |
    | Unity_v2020.1.0b6-linux-il2cpp.ulf.b64 | UNITY_2020_1_0b6_LICENSE_CONTENT_B64  |

3. All done!

If you're curious where the variable names are references; search for them in
the `.circleci/config.yml` file.

## NPM auth token

Whatever NPM registry used, it needs an authentication token for pushing the
new package version.

### NPM auth for Cloudsmith

1. Go to Cloudsmith API settings <https://cloudsmith.io/user/settings/api/>

2. If using a different NPM registry, update the `deploy-cloudsmith` job 
    inside the `.circleci/config.yml` file to use the appropriate URLS.

3. Copy the content of your Cloudsmith API token and add it as variable
    `NPM_AUTH_TOKEN` inside the CircleCI settings.

    >For jilleJr/Newtonsoft.Json-for-Unity.Converters, that page is found at
    ><https://app.circleci.com/settings/project/github/jilleJr/Newtonsoft.Json-for-Unity.Converters/environment-variables>

4. All done!

## Git deploy

Deployment is also done via GitHub. Deployment to GitHub is just done by
pushing the changes to the `upm` branch and then tagging that version with
the version number.

To be able to deploy to your repo, the build uses an SSH key for write access
and optionally a GPG key for commit/tag signing.

### UPM branch

Ensure you have a branch called `upm`

### Git SSH key

1. Generate a new SSH key, replacing `your_email@example.com` with
    the email address of the GitHub account that will be used for the auto
    deployment.

    ```sh
    $ ssh-keygen -t rsa -b 4096 -C "your_email@example.com"
    ```

    - When you're prompted to "Enter a file in which to save the key,", enter a
      new location such as `/home/your_user/.ssh/newtonsoft.json-for-unity.converters_rsa`

    - At the prompt, **enter no passphrase**.

2. Copy the content of the public key file
    (ex: `/home/your_user/.ssh/newtonsoft.json-for-unity.converters_rsa.pub`)
    into the GitHub project as a deploy key, naming it something like
    "Newtonsoft.Json-for-Unity.Converters UPM branch deployment key"

    >For jilleJr/Newtonsoft.Json-for-Unity.Converters, that page is found at
    ><https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/settings/keys/new>

    - Make sure to check the "Allow write access" checkbox.

3. Copy the content of the private key file
    (ex: `/home/your_user/.ssh/newtonsoft.json-for-unity.converters_rsa`)
    into the "Add SSH Key" dialog in CircleCI, specifying hostname as
    "github.com"
    
    >For jilleJr/Newtonsoft.Json-for-Unity.Converters, that page is found at
    ><https://app.circleci.com/settings/project/github/jilleJr/Newtonsoft.Json-for-Unity.Converters/ssh>

4. Copy the fingerprint of the new deploy key shown in CircleCIs UI

5. Update the `deploy-github` job 
    inside the `.circleci/config.yml` file to use the correct SSH key
    fingerprint.

    Example, where using the fingerprint
    `d7:ed:05:51:bd:95:3d:5b:dc:1f:97:00:6a:e5:b0:3c`:

    ```yaml
      - add_ssh_keys:
          fingerprints:
            - "d7:ed:05:51:bd:95:3d:5b:dc:1f:97:00:6a:e5:b0:3c"
    ```

### Git user info

This is used when creating commits and tags. Just basic user info is needed.

1. Add the git email of user that deploys as variable `GIT_USER_EMAIL`
   in CircleCI

2. Add the user name (display name) of user that deploys as variable
    `GIT_USER_NAME` in CircleCI

### Git GPG key

1. Generate key
   
    ```sh
    $ gpg --full-generate-key
    ```

    Use following generation instructions, **but no passphrase**:

    - kind: (1) RSA and RSA (default)
    - keysize: 4096
    - expiration: /up to you, ex: 1y/
    - real name: /full name of deploying user, first+last name/
    - email: /git email that's verified on github account of deploying user/
    - comment: /ex: Json.NET Unity Converters auto deployment to GitHub/

2. Find the newly generated key ID and paste it as variable `GIT_GPG_ID` in
    CircleCI. This key is referenced as `$KEY_ID` in the steps below.

    ```sh
    $ gpg --list-keys --keyid-format LONG
    ```

3. Add GPG public key to your GitHub account <https://github.com/settings/keys>
   
    ```sh
    $ gpg --armor --export $KEY_ID
    ```

4. Add GPG private key formatted base-64 formatted as variable
    `GIT_GPG_SEC_B64` in CircleCI.

    ```sh
    $ gpg --armor --export-secret-keys $KEY_ID | base64 -w0
    ```

5. All done!

## Summary: All CircleCI vars

List of all environment variables, to check if one is missing in CircleCI

| Variable name                           | Description                                        | Used in job              |
| --------------------------------------- | -------------------------------------------------- | ------------------------ |
| `UNITY_2018_4_14f1_LICENSE_CONTENT_B64` | License for Unity 2018.4.14f1                      | `test-unity-2018-4-14f1` |
| `UNITY_2019_2_11f1_LICENSE_CONTENT_B64` | License for Unity 2019.2.11f1                      | `test-unity-2019-2-11f1` |
| `UNITY_2020_1_0b6_LICENSE_CONTENT_B64`  | License for Unity 2020.1.0b6                       | `test-unity-2020-1-0b6`  |
| `NPM_AUTH_TOKEN`                        | Authorization token for publishing to NPM registry | `deploy-cloudsmith`      |
| `GIT_USER_EMAIL`                        | Git config `user.email`                            | `deploy-github`          |
| `GIT_USER_NAME`                         | Git config `user.name`                             | `deploy-github`          |
| `GIT_GPG_ID`\*                          | Git config `user.signingKey`                       | `deploy-github`          |
| `GIT_GPG_SEC_B64`\*                     | GPG secret/private. Required if GIT_GPG_ID is used | `deploy-github`          |

\* - Optional
