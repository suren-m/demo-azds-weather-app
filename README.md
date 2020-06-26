# demo-azds-weather-app

1. Create or Select `develop` devspace (no parent devspace needed)
```bash
azds space select
```

2. Prep and Deploy `Weather.Internal.Api` (keep this private)
```bash
cd ./Weather.Internal.Api/
azds prep
azds up
```

2. On a new tab, prep and deploy weather web to be public (just for demo) 
```bash
cd ./Weather.Web/
azds prep --enable-ingress  
azds up
```

3. On a separate tab, check status of services currently running in `develop` devspace
```bash
azds list-up
```

3. List available uris in `develop` devspace

```bash
azds list-uris
```

4. Choose `develop.weatherweb.######.uks.azds.io` to access the weather-app. (may take a few seconds to load upon first time)





