import db
from flask import Flask, request, Response
from flask_restful import Resource, Api, abort
import json
import datetime
import click

app = Flask(__name__)
api = Api(app)


MONTH_LIMIT = 6

def get_scores(user_id):
    data = json.load(open('../locations_visited.json'))
    factors = {}
    deltas = 0
    prev = None
    for monthly_data in data[:MONTH_LIMIT]:
        month = monthly_data['month']
        places = monthly_data['places']
        for place in places:
            factors[month] = place['count'] * place['price_level']
            if prev is not None:
                deltas += prev - factors[month]
            prev = factors[month]

    return factors, deltas


class Score(Resource):
    def get(self, user_id):
        scores, deltas = get_scores(user_id)
        response = {
            'factors': scores,
            'deltas': deltas,
        }
        return Response(json.dumps(response), mimetype='application/json')


api.add_resource(Score, '/api/score', '/api/score/<int:user_id>')


# CLI Implementation


@app.cli.command()
def initdb():
    try:
        db.Base.metadata.create_all(db.engine)
    except:
        print('Failed to create tables, please check the database' +
        'configuration and try again')

@app.cli.command()
@click.argument('userfilename')
@click.argument('scoresfilename')
def loaddata(userfilename, scoresfilename):
    db.Base.metadata.create_all(db.engine)
    session = db.Session()
    with open(userfilename) as infile:
        for line in infile:
            username, score, streak = line.split(', ')
            score = int(score)
            streak = int(streak)
            user = db.User(username=username, score=score, streak=streak)
            session.add(user)
    session.flush()
    session.commit()

    with open(scoresfilename) as infile:
        for line in infile:
            username, score, date = line.split(', ')
            score = int(score)
            score_obj = db.Score(username=username, score=score, date=date)
            session.add(score_obj)
    session.flush()
    session.commit()
