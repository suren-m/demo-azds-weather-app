# demo-azds-weather-app (own devspace)

For setting up develop devspace - see `develop` branch

1. Create a `ui-feature` devspace and use `develop` as parent (or create a devspace under your own name)
```bash
azds space select

# provide a name for new devspace - something like `ui-feature`

# choose the number of `develop` devspace when prompted to select a parent

```
3. On a new terminal, prep and deploy weather web (`--enable-ingress` if required for demo or just use port-forwarding)
```bash
cd ./Weather.Web/
azds prep --enable-ingress  
azds up
```

3. On a separate terminal, check status of services currently running in current devspace 
```bash
azds list-up
```

3. List available uris in current devspace (note the link to `develop` devspace for api

```bash
azds list-uris
```

4. Choose `ui-feature.s.weatherweb.######.uks.azds.io` to access the weather-app. (may take a few seconds to load upon first time)

5. Notice the changes. The ui in `develop.weatherweb.#####.uks.azds.io` should still remain intact

5. To display, all available uris use `azds list-uris --all`
