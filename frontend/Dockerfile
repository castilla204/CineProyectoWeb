
FROM node:latest AS build
WORKDIR /app
COPY ./package*.json ./
RUN npm install
COPY ./ .
RUN npm run build


FROM nginx:stable-alpine
COPY --from=build /app/dist /usr/share/nginx/html


#Ruta a archivo para configurar nginx y que no de error al recargar paginas
COPY default.conf /etc/nginx/conf.d/default.conf 
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]