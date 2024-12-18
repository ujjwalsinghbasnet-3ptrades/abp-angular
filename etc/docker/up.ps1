docker network create abppoc --label=abppoc
docker-compose -f docker-compose.infrastructure.yml up -d
exit $LASTEXITCODE