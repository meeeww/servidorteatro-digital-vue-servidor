# Crear un Cloud9 en AWS
Cambiamos storage de 10gb a 50gb

# Crear un Kluster de Kubernetes en AWS
Elastic Kubernetes Service
Versión 1.28
Subnets solo a, b y c
Sin security group

# Añadir credenciales
aws configure

region name: us-east-1
output: json

# Metemos las credenciales
Importante: Ir arriba a la derecha en el icono de ajustes, ir a AWS Settings > Credentials y desactivar AWS Managed credentials
Metemos las credenciales en ~/.aws/credentials con sudo nano

# Instalamos kubernetes en el Cloud9
Todo esto a partir del repo de Santos
https://github.com/santos-pardos/K8s-Eks

Instalamos KUBECTL, EKSCTL, Helm, Docker Compose, Telnet
sudo dnf install telnet

# Creamos Node groups en el Kluster
Compute > Node groups

# Editamos el SG de los Node groups
Todo el trafico desde esta ip: 172.31.0.0/16

# Añadimos el addon a Kluster
EBS CI Driver

# Clonar repo
git clone https://github.com/meeeww/servidorteatro-digital-vue-servidor

# Añadimos la bbdd a los kubernetes
kubectl apply -f kubernetes/sqlserver-deployment.yaml
kubectl apply -f kubernetes/sqlserver-svc.yaml

# Añadimos el puerto 30931 al SG de los Node groups
Para abrir el puerto del SQLServer

# Miramos qué IP ha recibido nuestra BBDD
kubectl get nodes -o wide

# Hacemos telnet de la IP de SQL
Si nos dice que nos hemos conectado, todo bien. En la string de conexión del .env tendremos que poner esa IP

# Creamos configmap del .env
kubectl delete configmap teatroapi-config
kubectl create configmap teatroapi-config --from-env-file=.env

# Instalamos Dotnet y Dotnet-ef
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo nano /etc/yum.repos.d/microsoft-prod.repo

[microsoft-prod]
name=Microsoft .NET
baseurl=https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod
enabled=1
gpgcheck=1
gpgkey=https://packages.microsoft.com/keys/microsoft.asc

sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo dnf config-manager --add-repo https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod
sudo dnf install dotnet-sdk-6.0

dotnet tool install --global dotnet-ef --version 6.*

# Hacemos las migraciones de la BBDD
En appsettings pondremos la IP a la que hicimos antes el telnet y el puerto

dotnet ef migrations add CreacionInicial -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj
dotnet ef migrations add MigracionInicial -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj

dotnet ef database update  -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj

# Subir repo a ECR (Elastic Container Registry)
https://us-east-1.console.aws.amazon.com/ecr/private-registry/repositories?region=us-east-1

# Añadir los contenedores a kubernetes
kubectl apply -f kubernetes/api-deployment.yaml
kubectl apply -f kubernetes/api-svc.yaml

# Final
Después de la útlima creación del Kluster, se nos creará un Load Balancer. A partir de ahí, le podemos añadir un DNS
