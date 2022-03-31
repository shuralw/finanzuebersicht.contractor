# build image
FROM node:12.7-alpine AS build
WORKDIR /build

# setup .npmrc
ARG BASE64_ENCODED_PERSONAL_ACCESS_TOKEN
COPY pipeline.npmrc .npmrc

# Copy package.json
COPY package.json .
COPY package-lock.json .

RUN npm config set proxy "http://wsg.asp.krzwan.de:8080/"

# Install dependencies
RUN npm install

# copy source code
COPY . .

# build angular project
RUN npm run build:prod
RUN rm -f .npmrc 

# base image
FROM nginxinc/nginx-unprivileged:stable-alpine AS base

# copy local artifact build
COPY --from=build /build/dist /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf

# run nginx
ENTRYPOINT ["nginx", "-g", "daemon off;"]

# expose port 8080
EXPOSE 8080

HEALTHCHECK CMD curl --fail http://localhost:8080 || exit
